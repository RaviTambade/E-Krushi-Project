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
      {orderid:1, image:'/assets/mira.webp',title:"Oberon",price:500, size:'100gm', quantity:3,total:1500 },
      {orderid:1, image:'/assets/mira.webp',title:"Goal",price:200, size:'100gm',quantity:2,total:400},
      {orderid:1, image:'/assets/mira.webp',title:"Targa",price:300, size:'100gm',quantity:3,total:900},
      {orderid:2, image:'/assets/mira.webp',title:"Saver sticker",price:100,size:'100gm',quantity:4,total:400},
      {orderid:2, image:'/assets/mira.webp',title:"Rogor",price:120,size:'100gm',quantity:5,total:600},
      {orderid:3, image:'/assets/mira.webp',title:"Mera 71",price:50,size:'100gm',quantity:2,total:100},
      {orderid:3, image:'/assets/mira.webp',title:"Avatar",price:150,size:'100gm',quantity:1,total:150},
    ];
    var filterdData=items.filter(item=> item.orderid ==orderId);
    return filterdData;
  }
}
