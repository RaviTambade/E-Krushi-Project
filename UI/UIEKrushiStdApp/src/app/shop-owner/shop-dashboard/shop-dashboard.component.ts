import { Component } from '@angular/core';
import { orderSp } from 'src/app/Models/orderSp';
import { StoreownerService } from 'src/app/Services/storeowner.service';

@Component({
  selector: 'app-shop-dashboard',
  templateUrl: './shop-dashboard.component.html',
  styleUrls: ['./shop-dashboard.component.css']
})
export class ShopDashboardComponent {

  constructor(private svc:StoreownerService){}

   todaysDate:='2023-07-08';
   storeId:number=1;
  
  orders!:orderSp;

  GetOrders(todaysDate:string,storeId :number){
      this.svc.getOrdersFromStoreProcedure(this.todaysDate,storeId).subscribe((res)=>{
    this.orders=res;
    console.log(this.orders);
    })
  }


}
