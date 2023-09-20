import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/app/Models/cart-item';
import { CartService } from 'src/app/Services/cart.service';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css'],
})
export class ShoppingcartComponent implements OnInit {
  items: CartItem[] = [];
  constructor(private cartsvc: CartService) {}
  ngOnInit(): void {
    this.cartsvc.getCartItems().subscribe((res) => {
      this.items = res;
    });
  }

  private showNotification(message: string) {
    // snackBar.open(message, 'Close', {
    //   duration: 3000, // Duration in milliseconds
    // });
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
        item.quantity = quantity;
      }
    });
  }
}
