import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderStatus } from 'src/app/Models/Enums/Order-Status';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { Order } from 'src/app/Models/Order';
import { OrderStatusCount } from 'src/app/Models/order-status-count';
import { OrderService } from 'src/app/Services/order-service.service';
import { StoreService } from 'src/app/Services/store.service';
import { ConfirmationBoxComponent } from 'src/app/confirmation-box/confirmation-box.component';

@Component({
  selector: 'app-shop-orders',
  templateUrl: './shop-orders.component.html',
  styleUrls: ['./shop-orders.component.css'],
})
export class ShopOrdersComponent implements OnInit {
  orders: Order[] = [];
  orderStatus = OrderStatus;
  selectedOrderId: number | null = null;
  isLoading: boolean = true;

  activeFilter: string = this.orderStatus.pending;
  orderCount: OrderStatusCount | null = null;

  constructor(
    private storesvc: StoreService,
    private ordersvc: OrderService,
    private route: ActivatedRoute,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));
    if (Number.isNaN(storeId) || storeId == 0) {
      return;
    }
    this.filterOrders(this.activeFilter);
    this.storesvc.getOrderCountByStatusAndStore(storeId).subscribe((res) => {
      this.orderCount = res;
    });
  }

  filterOrders(status: string) {
    this.activeFilter = status;
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));
    if (Number.isNaN(storeId) || storeId == 0) {
      return;
    }

    this.storesvc.getStoreOrders(storeId, status).subscribe({
      next: (res) => {
        this.orders = res;
        if (this.orders.length) {
          this.selectedOrderId = this.orders[0].id;
        } else {
          this.selectedOrderId = null;
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
  openApprovalConfirmationBox(orderId: number) {
    const message = 'Are you sure you want to Approve this Order?';
    const dialogRef = this.dialog.open(ConfirmationBoxComponent, {
      data: { message: message, status: 'Approval' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.onOrderApproved(orderId);
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
  openreadyToDispatchConfirmationBox(orderId: number) {
    const message = 'Are you sure you want to make Order Ready To Dispatch ?';
    const dialogRef = this.dialog.open(ConfirmationBoxComponent, {
      data: { message: message, status: 'Ready To Dispatch' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.onOrderReadyToDispatch(orderId);
      }
    });
  }

  onOrderApproved(orderId: number) {
    this.ordersvc
      .updateOrderStatus(orderId, OrderStatus.approved)
      .subscribe((res) => {
        if (res) {
          console.log('order approved');
          this.removeOrderFromCurrentOrders(orderId);
          if (this.orderCount != undefined) {
            this.orderCount.approved += 1;
            this.orderCount.pending -= 1;
          }
        }
      });
  }
  onOrderCancelled(orderId: number) {
    this.isLoading = true;
    this.ordersvc
      .updateOrderStatus(orderId, OrderStatus.cancelled)
      .subscribe({ next:(res) => {
        if (res) {
          console.log('order cancelled');
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


  onOrderReadyToDispatch(orderId: number) {
    this.isLoading = true;
    this.ordersvc
      .updateOrderStatus(orderId, OrderStatus.readyToDispatch)
      .subscribe({
        next: (res) => {
          if (res) {
            console.log('order ready for dispatch');
            this.removeOrderFromCurrentOrders(orderId);
            if (this.orderCount != undefined) {
              this.orderCount.approved -= 1;
              this.orderCount.readyToDispatch += 1;
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
    this.orders = this.orders.filter((o) => o.id != orderId);
    if (this.orders.length) {
      this.selectedOrderId = this.orders[0].id;
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