import { Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { OrderCount } from 'src/app/Models/orderCount';
import { BIService } from 'src/app/Services/bi.service';

@Component({
  selector: 'shop-orderscount',
  templateUrl: './orderscount.component.html',
  styleUrls: ['./orderscount.component.css']
})
export class OrderscountComponent implements OnInit{
  currentDate: string = new Date().toISOString().slice(0,10);

  orderCount:OrderCount={
    todaysOrders: 0,
    yesterdaysOrders: 0,
    weekOrders: 0,
    monthOrders: 0
  };
  constructor(private bisvc:BIService){ 
  }
  ngOnInit(): void {
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));
    if (Number.isNaN(storeId) || storeId == 0) {
      return;
    }

    this.bisvc.getOrderCountByStore(this.currentDate,storeId).subscribe((res)=>{
     
        this.orderCount=res;      
    })
  }


   
  
}
