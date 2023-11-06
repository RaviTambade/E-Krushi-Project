import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { OrderStatus } from '@enums/Order-Status';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { Order } from '@models/Order';
import { OrderStatusCount } from '@models/order-status-count';
import { OrderService } from '@services/order-service.service';
import { StoreService } from '@services/store.service';
import { ConfirmationBoxComponent } from 'app/confirmation-boxes/confirmation-box/confirmation-box.component';

@Component({
  selector: 'app-store-orders',
  templateUrl: './store-orders.component.html',
  styleUrls: ['./store-orders.component.css'],
})
export class StoreOrdersComponent implements OnInit {
  orders: Order[] = [];
  orderStatus = OrderStatus;
  selectedOrderId: number | null = null;
  isLoading: boolean = true;

  activeFilter: string = this.orderStatus.pending;
  orderCount: OrderStatusCount | null = null;

  constructor(
    private storesvc: StoreService,
    private ordersvc: OrderService,
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

    this.storesvc.getStoreOrders(storeId,status).subscribe({
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
