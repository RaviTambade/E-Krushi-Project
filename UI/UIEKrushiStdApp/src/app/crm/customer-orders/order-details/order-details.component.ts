import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Address } from '@models/address';
import { OrderService } from '@services/order-service.service';
import { UserService } from '@services/user.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  orderId!: number;
  address: Address | undefined;
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
