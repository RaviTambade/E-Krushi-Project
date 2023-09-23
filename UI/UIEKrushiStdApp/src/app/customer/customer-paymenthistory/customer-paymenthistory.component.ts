import { Component, OnInit } from '@angular/core';
import { Payment } from 'src/app/Models/Payment';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-customer-paymenthistory',
  templateUrl: './customer-paymenthistory.component.html',
  styleUrls: ['./customer-paymenthistory.component.css'],
})
export class CustomerPaymenthistoryComponent implements OnInit {
  constructor(private svc: PaymentService) {}
  customerid: number = 2;
  payments: Payment[] = [];
  ngOnInit(): void {
    this.svc.getPayments(this.customerid).subscribe((res) => {
      this.payments = res;
      console.log(res);
    });
  }
  viewStaus: boolean = false;
  selectedOrderId: number | null = null;

  viewPaymentDetails(orderId: number) {
    if (this.selectedOrderId === orderId) {
      this.viewStaus = !this.viewStaus;
    } else {
      this.selectedOrderId = orderId;
      this.viewStaus = true;
    }
  }
}
