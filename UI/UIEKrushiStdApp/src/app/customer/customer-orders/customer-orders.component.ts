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
   showSummery:boolean=false;
  constructor(private ordersvc: OrderService,private router:Router) {}
  ngOnInit(): void {
    this.orders = this.ordersvc.getOrders(1);
  }

 viewDetails(id: number) {
  this.showSummery=true;
    this.router.navigate(['customer/orders/details',id]);
  } 

}
