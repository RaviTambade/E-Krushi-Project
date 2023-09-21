import { Component, Input, OnInit } from '@angular/core';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-paymentsummery',
  templateUrl: './paymentsummery.component.html',
  styleUrls: ['./paymentsummery.component.css']
})
export class PaymentsummeryComponent implements OnInit {
  @Input() orderId!:number;
  
paymentDetails:any;
 constructor(private paymentsvc: PaymentService){}
  ngOnInit(): void {
    this.paymentsvc.getPaymentDetails(this.orderId).subscribe((res)=>{
      

    this.paymentDetails=res;
     console.log(this.orderId);
     console.log(res);
    })
  }

}
