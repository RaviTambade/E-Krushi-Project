import { Component, Input, OnInit } from '@angular/core';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-order-summery',
  templateUrl: './order-summery.component.html',
  styleUrls: ['./order-summery.component.css'],
})
export class OrderSummeryComponent implements OnInit {
  totalItems: string = '';
  subTotal: number = 0;
  discount: number = 0;
  shippingCharges = 'Free';
  total: number = 0;
  constructor(private ordersvc: OrderService) {}
  ngOnInit(): void {
    this.ordersvc.sendOrderData.subscribe((res: any) => {
      this.totalItems = res.totalItems;
      this.subTotal = res.subTotal;
      this.total = res.total;
    });
  }
}
