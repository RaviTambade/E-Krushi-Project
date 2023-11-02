import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-paymentsummery',
  templateUrl: './paymentsummery.component.html',
  styleUrls: ['./paymentsummery.component.css'],
})
export class PaymentsummeryComponent implements OnChanges {
  @Input() orderId!: number;
  PaymentId!: number;
  paymentDetails: any;
  constructor(private paymentsvc: PaymentService) {}
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['orderId'])
      this.paymentsvc
        .getPaymentDetails(changes['orderId'].currentValue)
        .subscribe((res) => {
          this.paymentDetails = res;
          this.PaymentId = res.paymentId;
          //
         
        });
  }
}
