import { Component, Input, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { SessionStorageKeys } from '@enums/session-storage-keys';
import { TokenClaims } from '@enums/tokenclaims';
import { PaymentAddModel } from '@models/PaymentAddModel';
import { PaymentTransferDetails } from '@models/PaymentTransferDetails';
import { BankAccount } from '@models/bankAccount';
import { CartItem } from '@models/cart-item';
import { OrderAddModel } from '@models/order-add-model';
import { OrderAmount } from '@models/order-amount';
import { OrderDetailsAddModel } from '@models/order-details-add-model';
import { AuthenticationService } from '@services/authentication.service';
import { BankingService } from '@services/banking.service';
import { CartService } from '@services/cart.service';
import { OrderService } from '@services/order-service.service';
import { PaymentGatewayService } from '@services/payment-gateway.service';
import { PaymentService } from '@services/payment.service';
import { StoreService } from '@services/store.service';
import { Observable, lastValueFrom, switchMap } from 'rxjs';

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
  orderedItems: CartItem[] = [];

  constructor(
    private banksvc: BankingService,
    private paymentsvc: PaymentService,
    private ordersvc: OrderService,
    private authsvc:AuthenticationService,
    private paymentgatewaysvc: PaymentGatewayService,
    private cartsvc: CartService,
    private storesvc: StoreService,
    private router: Router
  ) {}

  ngOnChanges(changes: SimpleChanges) {
    if (changes['orderedItems']) {
      this.orderedItems = changes['orderedItems'].currentValue;
    }
  }
  onPaymentOptionChange() {
    this.accountNumber = '';
    this.showPayButton = false;
    this.ifscCode = '';
  }

  onClickCheckAccount() {
    const customerId = Number(this.authsvc.getClaimFromToken(TokenClaims.userId)); 


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

  onMakePayment() {
    this.isPaymentButtonDisabled = true;

    const customerId = Number(this.authsvc.getClaimFromToken(TokenClaims.userId)); 
    const addressId = Number(
      sessionStorage.getItem(SessionStorageKeys.addressId)
    );

    if (
      Number.isNaN(customerId) ||
      Number.isNaN(addressId) ||
      customerId == 0 ||
      addressId == 0
    ) {
      return;
    }

    this.cartsvc.getCartItems().subscribe((res) => {
      if (sessionStorage.getItem(SessionStorageKeys.isBuyNow) == 'true') {
        this.orderedItems = [res.items[res.items.length - 1]];
      } else {
        this.orderedItems = res.items;
      }

      const order: OrderAddModel = {
        customerId: customerId,
        addressId: addressId,
        orderDetails: this.orderedItems.map(
          (item) =>
            new OrderDetailsAddModel(item.productDetailsId, item.quantity)
        ),
      };
  
      this.processOrder(order);
    });

  
  }

  processOrder(order: OrderAddModel) {
    this.ordersvc.createOrder(order).subscribe((res) => {
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
    if (sessionStorage.getItem(SessionStorageKeys.isBuyNow) == 'false') {
      this.cartsvc.RemoveAllItems().subscribe((res) => {});
    }
  }
}
