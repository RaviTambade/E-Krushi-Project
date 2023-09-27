import { Component, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-order-processing-main',
  templateUrl: './order-processing-main.component.html',
  styleUrls: ['./order-processing-main.component.css'],
})
export class OrderProcessingMainComponent implements OnDestroy {
  showOrderDetails = true;
  showAddress = false;
  showPayment = false;

  address: any;

  toggleAddress() {
    this.showAddress = !this.showAddress;
    this.showPayment = false;
    this.showOrderDetails = false;
  }

  toggleOrderDetails() {
    this.showOrderDetails = !this.showOrderDetails;
    this.showPayment = false;
    this.showAddress = false;
  }

  togglePayment() {
    this.showPayment = !this.showPayment;
    this.showAddress = false;
    this.showOrderDetails = false;
  }

  showAddAddress: boolean = false;

  onClickNewAddress() {
    this.showAddAddress = true;
  }

  hideAddressAddComponent() {
    this.showAddAddress = false;
  }

  onSelectedAddress(event: any) {
    this.showAddress = false;
    this.address = event.address;
  }

  ngOnDestroy(): void {
    sessionStorage.clear();
  }
}
