import { Component, Input, OnInit } from '@angular/core';
import { OrderDetails } from 'src/app/Models/orderDetails';
import { OrderService } from 'src/app/Services/order-service.service';

@Component({
  selector: 'app-order-summery',
  templateUrl: './order-summery.component.html',
  styleUrls: ['./order-summery.component.css']
})
export class OrderSummeryComponent implements OnInit{

  constructor(private ordersvc: OrderService){}
  subtotal:any;
  orderDetails:OrderDetails[]=[];
  @Input() orderId!:number;
  ngOnInit(): void {
    this.ordersvc.getOrdersDetails(this.orderId).subscribe((res) => {
      this.orderDetails = res;
      console.log(res);


      this.subtotal = 0;
      for (let i = 0; i < this.orderDetails.length; i++) {
        // Assuming data is an array of numbers, modify this as needed for your data structure
        this.subtotal += this.orderDetails[i].total;
        console.log(this.subtotal);
      }

    });
  }
}

