import { Component } from '@angular/core';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { PaymentAddModel } from 'src/app/Models/PaymentAddModel';
import { PaymentTransferDetails } from 'src/app/Models/PaymentTransferDetails';
import { BankingService } from 'src/app/Services/banking.service';
import { PaymentService } from 'src/app/Services/payment.service';

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

  constructor(
    private banksvc: BankingService,
    private paymentsvc: PaymentService
  ) {}
  onPaymentOptionChange() {
    this.accountNumber = '';
    this.showPayButton = false;
    this.ifscCode = '';
  }

  checkAccount() {
    this.banksvc.getAccount(this.accountNumber).subscribe((res) => {
      let bankAccount = res; 
      let customerId = Number(localStorage.getItem(LocalStorageKeys.userId));
      if (
        bankAccount.ifscCode == this.ifscCode &&
        bankAccount.customerId == customerId
      ) {
        this.showPayButton = true;
      }
    });
  }

  makePayment() {
    if (this.selectedMode === 'cash on delivery') {
      let payment: PaymentAddModel = {
        paymentStatus: 'unpaid',
        mode: 'cash on delivery',
        orderId: 0,
        transactionId: 0,
      };
      this.paymentsvc.addPayment(payment).subscribe((res) => {
        console.log('payment sone successfully and order placed');
      });
      
    } else if (this.selectedMode === 'net banking') {
      let paymentDetails: PaymentTransferDetails = {
        fromAcct: this.accountNumber,
        toAcct: '5642999999',
        fromIfsc: this.ifscCode,
        toIfsc: 'AXIS0000296',
        amount: 0,
      };
      this.banksvc.fundTransfer(paymentDetails).subscribe((res) => {
        if (res != 0) {
          let payment: PaymentAddModel = {
            paymentStatus: 'paid',
            mode: 'net banking',
            orderId: 0,
            transactionId: res,
          };
          this.paymentsvc.addPayment(payment).subscribe((res) => {
            console.log('payment sone successfully and order placed');
          });
        }
      });
    }
  }
}
