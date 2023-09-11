import { Injectable } from '@angular/core';
import { Order } from '../Models/Order';
import { OrderedItem } from '../Models/orderdItem';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor() {}

  getOrders(customerId: number):Order[] {
    var orders: Order[] = [
      { id: 1, date: '2023-09-11', amount: 4000, status: 'pending' },
      { id: 2, date: '2023-09-11', amount: 4200, status: 'deliverd' },
      { id: 3, date: '2023-09-11', amount: 900, status: 'cancelled' },
      { id: 4, date: '2023-09-11', amount: 12000, status: 'pending' },
    ];
    return orders;
  }
  

  getOrderdItems(orderId:number):OrderedItem[]{
    var items:OrderedItem[]=[
      {orderid:1, image:'/assets/mira.webp',title:"oberon",amount:500,quantity:3,total:1500},
      {orderid:1, image:'/assets/mira.webp',title:"goal",amount:200,quantity:2,total:400},
      {orderid:1, image:'/assets/mira.webp',title:"targa",amount:300,quantity:3,total:900},
      {orderid:2, image:'/assets/mira.webp',title:"saver sticker",amount:100,quantity:4,total:400},
      {orderid:2, image:'/assets/mira.webp',title:"rogor",amount:120,quantity:5,total:600},
      {orderid:3, image:'/assets/mira.webp',title:"mera 71",amount:50,quantity:2,total:100},
      {orderid:3, image:'/assets/mira.webp',title:"avatar",amount:150,quantity:1,total:150},
    ];
    var filterdData=items.filter(item=> item.orderid ==orderId);
    return filterdData;
  }
}
