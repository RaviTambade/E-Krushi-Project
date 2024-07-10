import { Component, Input, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderDetails } from '@models/orderDetails';
import { OrderedItem } from '@models/orderdItem';
import { OrderService } from '@services/order-service.service';


@Component({
  selector: 'app-order-product-details',
  templateUrl: './order-product-details.component.html',
  styleUrls: ['./order-product-details.component.css'],
})
export class OrderProductDetailsComponent {
  items: OrderedItem[] = [];
  orderDetails: OrderDetails[] = [];
  @Input() orderId!: number;
  isLoading: boolean = true;

  constructor(private ordersvc: OrderService) {}

  ngOnChanges(changes: SimpleChanges) {
    if (changes['orderId']) {
      this.isLoading = true;
      this.ordersvc
        .getOrdersDetails(changes['orderId'].currentValue)
        .subscribe({
          next: (res) => {
            this.orderDetails = res;
           
          },
          error: (error) => {
            console.error(error);
          },
          complete: () => {
            this.isLoading = false;
          }
        });  
    }
  }
}
