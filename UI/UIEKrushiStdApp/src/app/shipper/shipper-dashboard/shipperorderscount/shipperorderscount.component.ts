import { Component, OnInit } from '@angular/core';
import { OrderStatusCount } from 'src/app/Models/order-status-count';
import { ShipperService } from 'src/app/Services/shipper.service';

@Component({
  selector: 'app-shipperorderscount',
  templateUrl: './shipperorderscount.component.html',
  styleUrls: ['./shipperorderscount.component.css']
})
export class ShipperorderscountComponent implements OnInit{
  shipper:number=1;
  orderCount: OrderStatusCount={
    pending: 0,
    approved: 0,
    readyToDispatch: 0,
    picked: 0,
    inProgress: 0,
    delivered: 0,
    cancelled: 0
  };

constructor(private service:ShipperService){}
  ngOnInit(): void {
    this.service.getOrderCountByStatusAndShipper(this.shipper).subscribe((response)=>{
      console.log(response);
      this.orderCount=response;
    })
  }
}
