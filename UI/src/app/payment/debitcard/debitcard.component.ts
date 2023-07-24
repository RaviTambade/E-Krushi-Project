import { Component, OnInit } from '@angular/core';
import { PaymentService } from '../payment.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-debitcard',
  templateUrl: './debitcard.component.html',
  styleUrls: ['./debitcard.component.css']
})
export class DebitcardComponent implements OnInit {


  transactionId:any;
  cartId : any;
  successful:boolean=false;
  failed:boolean=false;
  credential:any={
    "fromAcct":'',
    "amount":0,
    "fromIfsc":'',
    "toAcct":'46556565566',
     "toIfsc":'AXIS0000296',
  }
  constructor(private svc:PaymentService){
    this.credential.amount=localStorage.getItem("total");
    this.cartId=localStorage.getItem("cartId");
  }
  ngOnInit(): void {
  }

 public onProceed(form:NgForm){
    this.credential.fromAcct=form.value.acctno;
    this.credential.amount=this.credential.amount;
    this.credential.fromIfsc=form.value.ifsc;
    console.log(this.credential.amount);
    this.svc.fundTransfer(this.credential).subscribe((res)=>{
      this.transactionId=res;
      console.log(this.transactionId);
      if(res){
        window.location.reload();
        alert("  Successfully");
      }
      else{
        alert("Error While deleting Record")
      }
    })
  }
  
  createOrder(cartId:any){
    console.log(this.cartId);
    this.svc.createOrder(this.cartId).subscribe((res)=>{
    console.log(this.cartId);
  });
 }
}
