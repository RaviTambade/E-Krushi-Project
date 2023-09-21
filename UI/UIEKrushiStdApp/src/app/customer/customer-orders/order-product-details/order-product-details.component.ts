import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderDetails } from 'src/app/Models/orderDetails';
import { OrderedItem } from 'src/app/Models/orderdItem';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-order-product-details',
  templateUrl: './order-product-details.component.html',
  styleUrls: ['./order-product-details.component.css']
})
export class OrderProductDetailsComponent {
  items: OrderedItem[] = [];
 subtotal:any;
  orderDetails:OrderDetails[]=[];
  @Input() orderId!:number;
  constructor(
    private ordersvc: OrderService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
   
    this.ordersvc.getOrdersDetails(this.orderId).subscribe((res) => {
      this.orderDetails = res;
      console.log(res);

     
  }
    );
  }



  
}
