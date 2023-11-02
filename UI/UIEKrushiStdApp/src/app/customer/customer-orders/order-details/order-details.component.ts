import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { AddressInfo } from 'src/app/Models/addressinfo';
import { OrderService } from 'src/app/Services/order-service.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  orderId!: number ;
  address: AddressInfo | undefined;
  constructor(
    private ordersvc: OrderService,
    private usersvc: UserService,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.orderId = Number(params.get('orderid'));
     
      this.ordersvc.getAddressIdOfOrder(this.orderId).subscribe((addressId) => {
        this.usersvc.getAddressById(addressId).subscribe((address) => {
          this.address = address;
        });
      });
    });
  }
}
