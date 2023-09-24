import { Component } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
})
export class PaymentComponent {
  selectedOption: string = 'COD';
  accountNumber: string = '';
  ifscCode: string = '';
  customerName: string = '';
  showPasswordInput: boolean = false;
  password: string = '';

  onPaymentOptionChange() {
    // if (this.selectedOption === 'Net Banking') {
      this.accountNumber = '';
      this.showPasswordInput=false;
      this.password=''
      this.customerName=''
      this.ifscCode=''
    // }

  }
  checkAccount() {
    this.showPasswordInput=true
  this.customerName='sahil mankar'
  }

  makePayment() {
    if (this.selectedOption === 'COD') {
      console.log('Processing Cash on Delivery payment');
    } else if (this.selectedOption === 'Net Banking') {
      console.log(
        `Processing Net Banking payment with account number: ${this.accountNumber}`
      );
    }
  }
}
