import { Component, OnInit } from '@angular/core';
import { Payment } from 'src/app/Models/Payment';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-customer-paymenthistory',
  templateUrl: './customer-paymenthistory.component.html',
  styleUrls: ['./customer-paymenthistory.component.css'],
})
export class CustomerPaymenthistoryComponent implements OnInit {

  constructor(private svc:PaymentService){}
  customerid:number=2;
  payments:Payment[]=[];
  ngOnInit(): void {
    this.svc.getPayments(this.customerid).subscribe((res) => {
      this.payments = res;
      console.log(res);
      
    });
  }
  viewStaus: boolean = false;
  selectedOrderId: number | null = null;
  paymentHistory: any = [
    { paymentId: 1, orderId: 1, orderdate: '10-02-2022', status: 'Paid' },
    { paymentId: 4, orderId: 2, orderdate: '12-06-2020', status: 'UnPaid' },
    { paymentId: 5, orderId: 3, orderdate: '16-05-2021', status: 'UnPaid' },
    { paymentId: 8, orderId: 4, orderdate: '04-05-2023', status: 'Paid' },
  ];
  viewPaymentDetails(orderId: number) {
    if (this.selectedOrderId === orderId) {
      this.viewStaus = !this.viewStaus;
    } else {
      this.selectedOrderId = orderId;
      this.viewStaus = true;
    }
  }

 
}
