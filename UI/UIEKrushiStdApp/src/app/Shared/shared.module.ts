import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { OrderProductDetailsComponent } from './order-product-details/order-product-details.component';
import { CartItemsComponent } from './cart-items/cart-items.component';
import { CartSummaryComponent } from './cart-summary/cart-summary.component';
import { SearchbarComponent } from './searchbar/searchbar.component';
import { FormsModule } from '@angular/forms';
import { DeleteConfirmationComponent } from '@ekrushi-confirmationboxes/delete-confirmation/delete-confirmation.component';
import { ConfirmationBoxComponent } from '@ekrushi-confirmationboxes/confirmation-box/confirmation-box.component';

@NgModule({
  declarations: [
    OrderProductDetailsComponent,
    CartItemsComponent,
    CartSummaryComponent,
    SearchbarComponent,
    DeleteConfirmationComponent,
    ConfirmationBoxComponent,
  ],
  imports: [CommonModule, RouterModule, FormsModule],
  exports: [
    OrderProductDetailsComponent,
    CartItemsComponent,
    CartSummaryComponent,
    SearchbarComponent,
  ],
})
export class SharedModule {}
