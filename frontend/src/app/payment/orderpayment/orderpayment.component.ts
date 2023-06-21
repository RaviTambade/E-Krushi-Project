import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PaymentService } from '../payment.service';
import { CreditCard } from '../creditcard';
import { DebitCard } from '../debitcard';

@Component({
  selector: 'app-orderpayment',
  templateUrl: './orderpayment.component.html',
  styleUrls: ['./orderpayment.component.css']
})
export class OrderpaymentComponent implements OnInit{
  ngOnInit(): void {
  }

  creditCard:CreditCard={
    id: 0,
    pinNumber: 0,
    accountId: 0,
    cardNumber: '',
    expiryDate:' ',
    cvv: 0,
    creditLimit: 0,
    balance: 0
  }

  debitCard:DebitCard={
    id: 0,
    customerId: 0,
    pinNumber: 0,
    accountId: 0,
    cardNumber: '',
    expiryDate: '',
    cvv: 0
  }



  constructor(private svc:PaymentService){}
 
  form = new FormGroup({
    payment: new FormControl('', Validators.required)
  });
    
  get f(){
    return this.form.controls;
  }
   
  submit(){
    console.log(this.form.value);
  }

  changePayment(e:any) {
    console.log(e.target.value);

    if(e.target.value=="credit card"){
        this.svc.addCreditCard(this.creditCard).subscribe((res)=>{
        this.creditCard = res;
      })
    }
    else(e.target.value=="Debit Card"){
        this.svc.addDebitCard(this.debitCard).subscribe((res)=>{
        this.debitCard = res;
      })
    }
}git
  
  



