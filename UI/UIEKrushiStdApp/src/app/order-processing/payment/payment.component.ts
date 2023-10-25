import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, firstValueFrom, lastValueFrom, switchMap } from 'rxjs';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { SessionStorageKeys } from 'src/app/Models/Enums/session-storage-keys';
import { PaymentAddModel } from 'src/app/Models/PaymentAddModel';
import { PaymentTransferDetails } from 'src/app/Models/PaymentTransferDetails';
import { BankAccount } from 'src/app/Models/bankAccount';
import { CartItem } from 'src/app/Models/cart-item';
import { OrderAddModel } from 'src/app/Models/order-add-model';
import { OrderAmount } from 'src/app/Models/order-amount';
import { OrderDetailsAddModel } from 'src/app/Models/order-details-add-model';
import { BankingService } from 'src/app/Services/banking.service';
import { CartService } from 'src/app/Services/cart.service';
import { OrderService } from 'src/app/Services/order-service.service';
import { PaymentGatewayService } from 'src/app/Services/payment-gateway.service';
import { PaymentService } from 'src/app/Services/payment.service';
import { StoreService } from 'src/app/Services/store.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
})
export class PaymentComponent {
  selectedMode: string = 'cash on delivery';
  accountNumber: string = '';
  ifscCode: string = '';
  showPayButton: boolean = false;
  isPaymentButtonDisabled: boolean = false;

  constructor(
    private banksvc: BankingService,
    private paymentsvc: PaymentService,
    private ordersvc: OrderService,
    private paymentgatewaysvc:PaymentGatewayService,
    private cartsvc: CartService,
    private storesvc: StoreService,
    private router: Router
  ) {}

  onPaymentOptionChange() {
    this.accountNumber = '';
    this.showPayButton = false;
    this.ifscCode = '';
  }

  checkAccount() {
    let customerId = Number(localStorage.getItem(LocalStorageKeys.userId));
    if (Number.isNaN(customerId) || customerId==0) {
      return;
    }

    this.banksvc.checkAccount(customerId).subscribe((res) => {
      let bankAccount = res;

      if (
        bankAccount.ifscCode == this.ifscCode &&
        bankAccount.accountNumber == this.accountNumber
      ) {
        this.showPayButton = true;
      }
    });
  }

  makePayment() {
    this.isPaymentButtonDisabled=true;
    const customerId = Number(localStorage.getItem(LocalStorageKeys.userId));
    const addressId = Number(
      sessionStorage.getItem(SessionStorageKeys.addressId)
    );

    if (Number.isNaN(customerId) || Number.isNaN(addressId)
    || customerId==0 ||addressId == 0) {
      return;
    }

    const cartItems = this.getCartItems();

    if (!cartItems || cartItems.length === 0) {
      return;
    }

    const orderdetails = this.createOrderDetails(cartItems);
    const order: OrderAddModel = {
      customerId: customerId,
      addressId: addressId,
      orderDetails: orderdetails,
    };

    this.processOrder(order);
  }

  getCartItems() {
    const items = sessionStorage.getItem(SessionStorageKeys.items);
    return items ? JSON.parse(items) : [];
  }

  createOrderDetails(cartItems: CartItem[]) {
    return cartItems.map(
      (item) =>
        new OrderDetailsAddModel(item.productId, item.quantity, item.size)
    );
  }

  processOrder(order: OrderAddModel) {
    this.ordersvc.processOrder(order).subscribe((res) => {
      console.log(res);
      const orderAmount = res;

      if (this.selectedMode === 'cash on delivery') {
        this.processCashOnDeliveryPayment(orderAmount.orderId);
      } else if (this.selectedMode === 'net banking') {
        this.processNetBankingPayment(orderAmount);
      }
    });
  }

  processCashOnDeliveryPayment(orderId: number) {
    const payment: PaymentAddModel = {
      paymentStatus: 'unpaid',
      mode: 'cash on delivery',
      orderId: orderId,
      transactionId: 0,
    };

    this.paymentsvc.addPayment(payment).subscribe((res) => {
      if (res) {
        this.emptyCart();
        alert('Order Placed');
        console.log('payment done successfully and order placed');
        this.router.navigate(['/']);
      }
    });
  }


  async processNetBankingPayment(orderAmount: OrderAmount) {
    try {
      const storeBankDetails = await lastValueFrom(
        this.fetchStoreAccountInfo(orderAmount.storeId)
      );

      const paymentDetails: PaymentTransferDetails = {
        fromAcct: this.accountNumber,
        toAcct: storeBankDetails.accountNumber,
        fromIfsc: this.ifscCode,
        toIfsc: storeBankDetails.ifscCode,
        amount: orderAmount.amount,
      };

      const res = await lastValueFrom(
        this.paymentgatewaysvc.fundTransfer(paymentDetails)
      );

      if (res !== 0) {
        const payment: PaymentAddModel = {
          paymentStatus: 'paid',
          mode: 'net banking',
          orderId: orderAmount.orderId,
          transactionId: res,
        };

        const paymentResult = await lastValueFrom(
          this.paymentsvc.addPayment(payment)
        );

        if (paymentResult) {
          this.emptyCart();
          alert('Order Placed');
          console.log('Payment done successfully, and order placed');
          this.router.navigate(['/']);
        }
      } else {
        console.error('Fund transfer failed');
      }
    } catch (error) {
      console.error('An error occurred during the payment process:', error);
    }
  }

  fetchStoreAccountInfo(storeId: number): Observable<BankAccount> {
    return this.storesvc.getStoreUserId(storeId).pipe(
      switchMap((storeUserId) => {
        return this.banksvc.checkAccount(storeUserId);
      })
    );
  }

  emptyCart() {
    if (sessionStorage.getItem(SessionStorageKeys.isFromCart) == 'true') {
      this.cartsvc.RemoveAllCartItems().subscribe((res) => {});
    }
  }
}
