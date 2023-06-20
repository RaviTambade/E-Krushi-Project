import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-orderpayment',
  templateUrl: './orderpayment.component.html',
  styleUrls: ['./orderpayment.component.css']
})
export class OrderpaymentComponent {


  
  form = new FormGroup({
    gender: new FormControl('', Validators.required)
  });
   
  
  get f(){
    return this.form.controls;
  }
   
  submit(){
    console.log(this.form.value);
  }
 

  changePayment(e:any) {
    console.log(e.target.value);
}
}
