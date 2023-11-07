import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { OrderStatus } from '@enums/Order-Status';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { OrderStatusCount } from '@models/order-status-count';
import { ShipperOrder } from '@models/shipper-order';
import { OrderService } from '@services/order-service.service';
import { ShipperService } from '@services/shipper.service';
import { UserService } from '@services/user.service';
import { ConfirmationBoxComponent } from 'app/confirmation-boxes/confirmation-box/confirmation-box.component';

@Component({
  selector: 'app-shipper-orders',
  templateUrl: './shipper-orders.component.html',
  styleUrls: ['./shipper-orders.component.css'],
})
export class ShipperOrdersComponent {
  orders: ShipperOrder[] = [];
  orderStatus = OrderStatus;
  selectedOrderId: number | null = null;
  isLoading: boolean = true;

  activeFilter: string = this.orderStatus.readyToDispatch;
  orderCount: OrderStatusCount | null = null;

  constructor(
    private shippersvc: ShipperService,
    private usersvc: UserService,
    private ordersvc: OrderService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    const shipperId = Number(localStorage.getItem(LocalStorageKeys.shipperId));
    if (Number.isNaN(shipperId) || shipperId == 0) {
      return;
    }

    this.filterOrders(this.activeFilter);
    this.shippersvc
      .getOrderCountByStatusAndShipper(shipperId)
      .subscribe((res) => {
        this.orderCount = res;
      });
  }

  filterOrders(status: string) {
    this.activeFilter = status;
    const shipperId = Number(localStorage.getItem(LocalStorageKeys.shipperId));
    if (Number.isNaN(shipperId) || shipperId == 0) {
      return;
    }

    this.shippersvc.getShipperOrders(shipperId, status).subscribe({
      next: (res) => {
        this.orders = res;
        if (this.orders.length) {
          this.selectedOrderId = this.orders[0].orderId;
        } else {
          this.selectedOrderId = null;
        }

        if(this.orders.length>0){
        let addressIds: number[] = this.orders.reduce<number[]>((acc, o) => {
          acc.push(o.fromAddressId, o.toAddressId);
          return acc;
        }, []);
        let uniqueaddressIds = [...new Set(addressIds)].join(',');

        this.usersvc
          .getaddressInfoByIds(uniqueaddressIds)
          .subscribe((res) => {
            let addresses = res;
            this.orders.forEach((order) => {
              const match1 = addresses.find(
                (address) => address.id === order.fromAddressId
              );
              if (match1) {
                order.fromAddress = `${match1.name}, ${match1.landMark}, ${match1.area},${match1.city}, ${match1.state},${match1.pinCode} ,${match1.contactNumber}, ${match1.alternateContactNumber}`;
               
              }
              const match2 = addresses.find(
                (address) => address.id === order.toAddressId
              );
              if (match2) {
                order.toAddress =`${match2.name}, ${match2.landMark}, ${match2.area},${match2.city}, ${match2.state},${match2.pinCode} ,${match2.contactNumber}, ${match2.alternateContactNumber}`;

              }
            });
          });
        }
      },
    
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }

  openPickedConfirmationBox(orderId: number) {
    const message =
      'Are you certain you want to update this order status to Picked?';
    const dialogRef = this.dialog.open(ConfirmationBoxComponent, {
      data: { message: message, status: 'Pick' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.onOrderPicked(orderId);
      }
    });
  }

  openCancellationConfirmationBox(orderId: number) {
    const message = 'Are you sure you want to cancel this Order?';
    const dialogRef = this.dialog.open(ConfirmationBoxComponent, {
      data: { message: message, status: 'Cancellation' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.onOrderCancelled(orderId);
      }
    });
  }

  openInprogressConfirmationBox(orderId: number) {
    const message =
      'Are you certain you want to update this order status to In Processing?';
    const dialogRef = this.dialog.open(ConfirmationBoxComponent, {
      data: { message: message, status: 'Processing' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.onOrderInProgress(orderId);
      }
    });
  }

  openDeliveredConfirmationBox(orderId: number) {
    const message =
      "Are you certain you want to update this order status to 'Delivered'?";
    const dialogRef = this.dialog.open(ConfirmationBoxComponent, {
      data: { message: message, status: 'Deliverd' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.onOrderDelivered(orderId);
      }
    });
  }

  onOrderPicked(orderId: number) {
    this.isLoading = true;
    this.ordersvc.updateOrderStatus(orderId, OrderStatus.picked).subscribe({
      next: (res) => {
        if (res) {
         
          this.removeOrderFromCurrentOrders(orderId);
          if (this.orderCount != undefined) {
            this.orderCount.readyToDispatch -= 1;
            this.orderCount.picked += 1;
          }
        }
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
  onOrderCancelled(orderId: number) {
    this.isLoading = true;
    this.ordersvc.updateOrderStatus(orderId, OrderStatus.cancelled).subscribe({
      next: (res) => {
        if (res) {
         
          this.removeOrderFromCurrentOrders(orderId);
          if (this.orderCount != undefined) {
            this.orderCount.cancelled += 1;
            this.orderCount.pending -= 1;
          }
        }
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }

  onOrderInProgress(orderId: number) {
    this.isLoading = true;
    this.ordersvc.updateOrderStatus(orderId, OrderStatus.inprogress).subscribe({
      next: (res) => {
        if (res) {
         
          this.removeOrderFromCurrentOrders(orderId);
          if (this.orderCount != undefined) {
            this.orderCount.picked -= 1;
            this.orderCount.inProgress += 1;
          }
        }
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }

  onOrderDelivered(orderId: number) {
    this.isLoading = true;
    this.ordersvc.updateOrderStatus(orderId, OrderStatus.delivered).subscribe({
      next: (res) => {
        if (res) {
         
          this.removeOrderFromCurrentOrders(orderId);
          if (this.orderCount != undefined) {
            this.orderCount.inProgress -= 1;
            this.orderCount.delivered += 1;
          }
        }
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
  removeOrderFromCurrentOrders(orderId: number) {
    this.orders = this.orders.filter((o) => o.orderId != orderId);
    if (this.orders.length) {
      this.selectedOrderId = this.orders[0].orderId;
    } else {
      this.selectedOrderId = null;
    }
  }
  onDetailsClick(orderId: number) {
    if (this.selectedOrderId == null || this.selectedOrderId != orderId) {
      this.selectedOrderId = orderId;
    } else {
      this.selectedOrderId = null;
    }
  }
}
