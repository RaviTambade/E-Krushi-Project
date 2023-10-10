import { Component, OnInit } from '@angular/core';
import { OrderStatus } from 'src/app/Models/Enums/Order-Status';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { Order } from 'src/app/Models/Order';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styleUrls: ['./customer-orders.component.css'],
})
export class CustomerOrdersComponent implements OnInit {
  orders: Order[] = [];
  orderStatus=OrderStatus;
  filteredOrders: Order[] = [];
  activeFilter: string = this.orderStatus.pending;
  isLoading: boolean = true;
  constructor(private ordersvc: OrderService) {}

  ngOnInit(): void {
    const customerId = Number(localStorage.getItem(LocalStorageKeys.userId));
      this.ordersvc.getOrdersOfCustomer(customerId).subscribe({
        next: (res) => {
          this.orders = res;
          this.filterOrders(this.activeFilter);
          console.log(res);
        },
        error: (error) => {
          console.error(error);
        },
        complete: () => {
          this.isLoading = false;
        },
      });
  }

  filterOrders(status: string) {
    this.activeFilter = status;
    if (status == 'all') {
      this.filteredOrders = this.orders;
    } else {
      this.filteredOrders = this.orders.filter(
        (order) => order.status == status
      );
    }
  }
}
