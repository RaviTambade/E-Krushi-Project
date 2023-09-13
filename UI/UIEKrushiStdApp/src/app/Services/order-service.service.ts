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
      {orderid:1, imageUrl:'/assets/antracol2.jpeg',title:"Antracol",price:500, size:'100gm', quantity:3,total:1500 },
      {orderid:1, imageUrl:'/assets/Goal.jpeg',title:"Goal",price:200, size:'100gm',quantity:2,total:400},
      {orderid:1, imageUrl:'/assets/targa-super.png',title:"Targa",price:300, size:'100gm',quantity:3,total:900},
      {orderid:2, imageUrl:'/assets/coragen.jpeg',title:"Coragen",price:100,size:'100gm',quantity:4,total:400},
      {orderid:2, imageUrl:'/assets/Rogor.jpeg',title:"Rogor",price:120,size:'100gm',quantity:5,total:600},
      {orderid:3, imageUrl:'/assets/mira.webp',title:"Mera 71",price:50,size:'100gm',quantity:2,total:100},
      {orderid:3, imageUrl:'/assets/Avtar.jpeg',title:"Avatar",price:150,size:'100gm',quantity:1,total:150},
    ];
    var filterdData=items.filter(item=> item.orderid ==orderId);
    return filterdData;
  }
}
