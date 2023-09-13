import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderedItem } from 'src/app/Models/orderdItem';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-order-product-details',
  templateUrl: './order-product-details.component.html',
  styleUrls: ['./order-product-details.component.css']
})
export class OrderProductDetailsComponent {
  items: OrderedItem[] = [];
  orderId: number = 0;

  constructor(
    private ordersvc: OrderService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.orderId = Number(params.get('orderid'));
      this.items = this.ordersvc.getOrderdItems(this.orderId);
    });
  }
}
