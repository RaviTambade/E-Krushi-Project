import { Component, OnDestroy } from '@angular/core';
import { SessionStorageKeys } from '@enums/session-storage-keys';
import { CartItem } from '@models/cart-item';
import { CartService } from '@services/cart.service';

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
  items: CartItem[] = [];
  totalItems: string = '';
  subTotal: number = 0;
  discount: number = 0;
  shippingCharges = 'Free';
  total: number = 0;

  constructor(private cartsvc: CartService) {}

  ngOnInit(): void {
    this.cartsvc.getCartItems().subscribe((res) => {
      if (sessionStorage.getItem(SessionStorageKeys.isBuyNow) == 'true') {
        this.items = [res.items[res.items.length - 1]];
      } else {
        this.items = res.items;
      }
    });
  }
  onReceiveData(event: any) {
    this.totalItems = event.totalItems;
    this.subTotal = event.subTotal;
    this.total = event.total;
  }
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




  onSelectedAddress(event: any) {
    this.showAddress = false;
    this.address = event.address;
  }

  ngOnDestroy(): void {
    if (sessionStorage.getItem(SessionStorageKeys.isBuyNow) == 'true') {
      this.cartsvc
        .RemoveItem(this.items[0].productDetailsId)
        .subscribe((res) => {});
    }
    sessionStorage.clear();
  }
}
