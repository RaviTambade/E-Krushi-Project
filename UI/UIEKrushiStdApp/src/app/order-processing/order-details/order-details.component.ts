import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SessionStorageKeys } from 'src/app/Models/Enums/session-storage-keys';
import { CartItem } from 'src/app/Models/cart-item';
import { CartService } from 'src/app/Services/cart.service';
import { OrderService } from 'src/app/Services/order-service.service';
import { DeleteConfirmationComponent } from 'src/app/delete-confirmation/delete-confirmation.component';

@Component({
  selector: 'orderprocessing-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnDestroy {
  items: CartItem[] = [];
  totalItems: string = '';
  subTotal: number = 0;
  discount: number = 0;
  shippingCharges = 'Free';
  total: number = 0;

  maxAllowedQuantity: number = 10;
  minAllowedQuantity: number = 1;
  constructor(
    private ordersvc: OrderService,
    private cartsvc: CartService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    let items = sessionStorage.getItem(SessionStorageKeys.items);
    if (items == null) {
      return;
    }
    this.items = JSON.parse(items);
    this.calculateSummary();
  }

  private calculateSummary() {
    this.totalItems = this.items.length.toString();
    this.subTotal = 0;
    this.items
      .map((item) => item.quantity * item.unitPrice)
      .forEach((i) => (this.subTotal += i));
    this.total = this.subTotal - this.discount;

    this.ordersvc.sendOrderData.next({
      totalItems: this.totalItems,
      subTotal: this.subTotal,
      total: this.total,
    });
  }

  openDeleteConfirmationDialog(cartItemId: number) {
    const dialogRef = this.dialog.open(DeleteConfirmationComponent, {});

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.deleteItem(cartItemId);
      }
    });
  }

  deleteItem(cartItemId: number) {
    this.items = this.items.filter((item) => item.productDetailsId != cartItemId);
    this.calculateSummary();
  }

  showNotification(message: string) {
    this.snackBar.open(message, '', {
      duration: 3000,
      verticalPosition: 'bottom',
      horizontalPosition: 'center',
    });
  }

  onClickDecrement(item: CartItem) {
    let newQuantity = item.quantity - 1;
    if (newQuantity < this.minAllowedQuantity) {
      newQuantity = this.minAllowedQuantity;
    }
    this.updateDatabaseQuantity(item, newQuantity);
  }
  onClickIncrement(item: CartItem) {
    let newQuantity = item.quantity + 1;

    if (newQuantity > this.maxAllowedQuantity) {
      newQuantity = this.maxAllowedQuantity;
    }
    this.updateDatabaseQuantity(item, newQuantity);
  }

  updateQuantity(item: CartItem, event: any) {
    let newQuantity = event.target.value;
    if (newQuantity > this.maxAllowedQuantity) {
      newQuantity = this.maxAllowedQuantity;
    }
    if (newQuantity < this.minAllowedQuantity) {
      newQuantity = this.minAllowedQuantity;
    }

    this.updateDatabaseQuantity(item, newQuantity);
  }

  updateDatabaseQuantity(item: CartItem, quantity: number) {
    if (quantity == item.quantity && quantity == this.maxAllowedQuantity) {
      this.showNotification(
        `Maximum ${this.maxAllowedQuantity} Quantity Per Order is allowed`
      );
      return;
    }
    if (quantity == item.quantity && quantity == this.minAllowedQuantity) {
      this.showNotification(
        `Minimum ${this.minAllowedQuantity} Quantity Per Order is allowed`
      );
      return;
    }

    this.showNotification(
      `You  Changed  ${item.title}  Quantity  To  ${quantity}`
    );
    item.quantity = quantity;
    console.log(this.items);
    this.calculateSummary();
  }

  ngOnDestroy(): void {
    sessionStorage.setItem(
      SessionStorageKeys.items,
      JSON.stringify(this.items)
    );

  }
}
