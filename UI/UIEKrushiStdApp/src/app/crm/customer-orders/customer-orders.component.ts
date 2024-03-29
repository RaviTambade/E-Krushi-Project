import { Component, OnInit } from '@angular/core';
import { OrderStatus } from '@enums/Order-Status';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { TokenClaims } from '@enums/tokenclaims';
import { Order } from '@models/Order';
import { AuthenticationService } from '@services/authentication.service';
import { OrderService } from '@services/order-service.service';

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styleUrls: ['./customer-orders.component.css'],
})
export class CustomerOrdersComponent implements OnInit {
  orders: Order[] = [];
  orderStatus = OrderStatus;
  activeFilter: string = this.orderStatus.pending;
  isLoading: boolean = true;
  fromDate:string='';
  toDate:string='';
  constructor(private ordersvc: OrderService,private authsvc:AuthenticationService) {}

  ngOnInit(): void {
    this.filterOrders(this.orderStatus.pending);
  }
  onSubmit(){
    // console.log(this.fromDate)
    // console.log(this.toDate)
  }

  filterOrders(status: string) {
    this.activeFilter = status;
    const customerId =  Number(
      this.authsvc.getClaimFromToken(TokenClaims.userId)
    );
    this.ordersvc.getOrdersOfCustomer(customerId, this.activeFilter).subscribe({
      next: (res) => {
        this.orders = res;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}
