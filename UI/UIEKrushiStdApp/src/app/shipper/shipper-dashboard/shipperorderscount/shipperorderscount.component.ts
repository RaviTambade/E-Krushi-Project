import { Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { OrderStatusCount } from '@models/order-status-count';
import { ShipperService } from '@services/shipper.service';

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

constructor(private shippersvc:ShipperService){}
  ngOnInit(): void {

    const shipperId = Number(localStorage.getItem(LocalStorageKeys.shipperId));
    if (Number.isNaN(shipperId) || shipperId == 0) {
      return;
    }

    this.shippersvc.getOrderCountByStatusAndShipper(shipperId).subscribe((response)=>{
     
      this.orderCount=response;
    })
  }
}
