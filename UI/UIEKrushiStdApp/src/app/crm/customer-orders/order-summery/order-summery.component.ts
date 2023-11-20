import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { OrderService } from '@services/order-service.service';


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

     
      this.subtotal = res;
    });
  }
}
