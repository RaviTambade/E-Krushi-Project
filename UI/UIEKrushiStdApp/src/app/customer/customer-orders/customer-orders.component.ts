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
  orderStatus = OrderStatus;
  activeFilter: string = this.orderStatus.pending;
  isLoading: boolean = true;
  fromDate:string='';
  toDate:string='';
  constructor(private ordersvc: OrderService) {}

  ngOnInit(): void {
    this.filterOrders(this.orderStatus.pending);
  }
  onSubmit(){
    console.log(this.fromDate)
    console.log(this.toDate)
  }

  filterOrders(status: string) {
    this.activeFilter = status;
    const customerId = Number(localStorage.getItem(LocalStorageKeys.userId));
    this.ordersvc.getOrdersOfCustomer(customerId, this.activeFilter).subscribe({
      next: (res) => {
        this.orders = res;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}
