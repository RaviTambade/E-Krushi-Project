import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PaymentService } from '../payment.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-orderpayment',
  templateUrl: './orderpayment.component.html',
  styleUrls: ['./orderpayment.component.css']
})
export class OrderpaymentComponent implements OnInit{

  ngOnInit(): void {
  }

  constructor(private svc:PaymentService,private router:Router,private route:ActivatedRoute){}
 
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

    if(e.target.value){
  
    if(e.target.value=="debit card"){
      this.router.navigate(['./debitcard'],{relativeTo:this.route});
    }   
  }
 }
}

  



