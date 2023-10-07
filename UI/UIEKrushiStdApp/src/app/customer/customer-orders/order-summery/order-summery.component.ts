import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { OrderDetails } from 'src/app/Models/orderDetails';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-order-summery',
  templateUrl: './order-summery.component.html',
  styleUrls: ['./order-summery.component.css'],
})
export class OrderSummeryComponent implements OnInit {
  constructor(private ordersvc: OrderService) {}
  subtotal: number | null = null;
  @Input() orderId!: number;
  ngOnInit(): void {
    this.ordersvc.getOrderAmount(this.orderId).subscribe((res) => {

      console.log(res);
      this.subtotal = res;
    });
  }
}
