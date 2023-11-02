import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { Payment } from 'src/app/Models/Payment';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-customer-paymenthistory',
  templateUrl: './customer-paymenthistory.component.html',
  styleUrls: ['./customer-paymenthistory.component.css'],
})
export class CustomerPaymenthistoryComponent implements OnInit {
  constructor(private svc: PaymentService) {}

  payments: Payment[] = [];
  ngOnInit(): void {
    const customerId = Number(localStorage.getItem(LocalStorageKeys.userId));

    this.svc.getPayments(customerId).subscribe((res) => {
      this.payments = res;
     
    });
  }
  viewStatus: boolean = false;
  selectedOrderId: number | null = null;

  viewPaymentDetails(orderId: number) {
    if (this.selectedOrderId == orderId) {
      this.viewStatus = false;
      this.selectedOrderId = null;
    } else{
      this.viewStatus = true;
      this.selectedOrderId = orderId;
    }
  }
}
