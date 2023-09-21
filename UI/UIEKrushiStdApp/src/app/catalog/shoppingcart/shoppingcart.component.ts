import { Component, OnInit } from '@angular/core';
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
  constructor(
    private cartsvc: CartService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.cartsvc.getCartItems().subscribe((res) => {
      this.items = res;
    });
  }

  openDeleteConfirmationDialog(cartItemId:number) {
    const dialogRef = this.dialog.open(DeleteConfirmationComponent, {
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.deleteItem(cartItemId);
      } else {
      }
    });
  }

  deleteItem(cartItemId: number) {
    this.cartsvc.RemoveItem(cartItemId).subscribe((res) => {
      if (res) {
        this.items = this.items.filter((item) => item.cartItemId != cartItemId);
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
    if (newQuantity < 1) {
      newQuantity = 1;
    }
    this.updateDatabaseQuantity(item, newQuantity);
  }
  onClickIncrement(item: CartItem) {
    let newQuantity = item.quantity + 1;

    if (newQuantity > 10) {
      newQuantity = 10;
    }
    this.updateDatabaseQuantity(item, newQuantity);
  }

  updateQuantity(item: CartItem, event: any) {
    let newQuantity = event.target.value;
    if (newQuantity > 10) {
      newQuantity = 10;
    }
    if (newQuantity < 1) {
      newQuantity = 1;
    }

    this.updateDatabaseQuantity(item, newQuantity);
  }

  updateDatabaseQuantity(item: CartItem, quantity: number) {
    this.cartsvc.updateQuantity(item.cartItemId, quantity).subscribe((res) => {
      if (res) {
        this.showNotification(
          `You  Changed  ${item.title}  Quantity  To  ${quantity}`
        );
        item.quantity = quantity;
      }
    });
  }
}
