import { Component, OnInit } from '@angular/core';
import { OrderStatus } from 'src/app/Models/Enums/Order-Status';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { Order } from 'src/app/Models/Order';
import { StoreService } from 'src/app/Services/store.service';

@Component({
  selector: 'app-shop-orders',
  templateUrl: './shop-orders.component.html',
  styleUrls: ['./shop-orders.component.css'],
})
export class ShopOrdersComponent implements OnInit {
  orders: Order[] = [];
  orderStatus = OrderStatus;

  activeFilter: string = this.orderStatus.pending;

  constructor(private storesvc: StoreService) {}

  ngOnInit(): void {
    this.filterOrders(this.activeFilter);
    console.log("c r")
  }

  filterOrders(status: string) {
    this.activeFilter=status;
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));
    if (Number.isNaN(storeId)) {
      return;
    }
    this.storesvc.getStoreOrders(storeId, status).subscribe((res) => {
      this.orders = res;
    });
  }
}
