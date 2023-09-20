import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from 'src/app/Models/Order';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styleUrls: ['./customer-orders.component.css'],
})
export class CustomerOrdersComponent implements OnInit {
  orders: Order[] = [];
  customerid: number = 3;
  filteredOrders: Order[] = [];
  activeFilter: string | null = null;
  subtotal!:number;
  data:any;
  constructor(private ordersvc: OrderService, private router: Router) {}

  ngOnInit(): void {
    this.ordersvc.getOrdersOfCustomer(this.customerid).subscribe((res) => {
      this.orders = res;
      // this.data=res.total;

      this.filteredOrders = res;
      console.log(res);



      

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
