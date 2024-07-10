import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { TokenClaims } from '@enums/tokenclaims';
import { Payment } from '@models/Payment';
import { AuthenticationService } from '@services/authentication.service';
import { PaymentService } from '@services/payment.service';

@Component({
  selector: 'app-customer-paymenthistory',
  templateUrl: './customer-paymenthistory.component.html',
  styleUrls: ['./customer-paymenthistory.component.css'],
})
export class CustomerPaymenthistoryComponent implements OnInit {
  constructor(private svc: PaymentService,
    private authsvc:AuthenticationService) {}

  payments: Payment[] = [];
  ngOnInit(): void {
    const customerId =  Number(this.authsvc.getClaimFromToken(TokenClaims.userId) );

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
