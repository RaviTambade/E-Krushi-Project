import { Component,  OnInit} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CartItem } from 'src/app/Models/cart-item';
import { CartService } from 'src/app/Services/cart.service';
import { DeleteConfirmationComponent } from 'src/app/delete-confirmation/delete-confirmation.component';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css'],
})
export class ShoppingcartComponent implements OnInit {
  items: CartItem[] = [];
  totalItems: string = '';
  subTotal: number = 0;
  discount: number = 0;
  shippingCharges = 'Free';
  total: number = 0;

  maxAllowedQuantity: number = 10;
  minAllowedQuantity: number = 1;
  constructor(
    private cartsvc: CartService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.cartsvc.getCartItems().subscribe((res) => {
      this.items = res;
      this.calculateSummary();
    });
  }

  private calculateSummary() {
    this.totalItems = this.items.length.toString();
    this.subTotal = 0;
    this.items
      .map((item) => item.quantity * item.unitPrice)
      .forEach((i) => (this.subTotal += i));
    this.total = this.subTotal - this.discount;
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
    this.cartsvc.RemoveItem(cartItemId).subscribe((res) => {
      if (res) {
        this.items = this.items.filter((item) => item.cartItemId != cartItemId);
        this.calculateSummary();
      }
    });
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
    if ( quantity == item.quantity &&  quantity == this.maxAllowedQuantity) {
      this.showNotification(`Maximum ${this.maxAllowedQuantity} Quantity Per Order is allowed`);
      return;
    }
    if ( quantity == item.quantity &&  quantity == this.minAllowedQuantity) {
      this.showNotification(`Minimum ${this.minAllowedQuantity} Quantity Per Order is allowed`);
      return;
    }
    this.cartsvc.updateQuantity(item.cartItemId, quantity).subscribe((res) => {
      if (res) {
        this.showNotification(
          `You  Changed  ${item.title}  Quantity  To  ${quantity}`
        );
      }
      item.quantity = quantity;
      console.log(this.items);
      this.calculateSummary();
    });
  }
}
