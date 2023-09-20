import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Order } from 'src/app/Models/Order';
import { OrderedItem } from 'src/app/Models/orderdItem';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  constructor(private router: Router,private route: ActivatedRoute) {}
  orderId!:number;
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.orderId = Number(params.get('orderid'));
      console.log(this.orderId);
      // this.items = this.ordersvc.getOrderdItems(this.orderId);
    });
  }
  






}
