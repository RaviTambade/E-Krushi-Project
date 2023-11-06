import { Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { OrderCount } from '@models/orderCount';
import { BIService } from '@services/bi.service';

@Component({
  selector: 'store-orderscount',
  templateUrl: './orderscount.component.html',
  styleUrls: ['./orderscount.component.css'],
})
export class OrderscountComponent implements OnInit {
  currentDate: string = new Date().toISOString().slice(0, 10);

  orderCount: OrderCount = {
    todaysOrders: 0,
    yesterdaysOrders: 0,
    weekOrders: 0,
    monthOrders: 0,
  };
  constructor(private bisvc: BIService) {}
  ngOnInit(): void {
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));
    if (Number.isNaN(storeId) || storeId == 0) {
      return;
    }

    this.bisvc
      .getOrderCountByStore(this.currentDate, storeId)
      .subscribe((res) => {
        this.orderCount = res;
      });
  }
}
