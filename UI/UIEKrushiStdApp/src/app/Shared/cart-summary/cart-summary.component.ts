import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrls: ['./cart-summary.component.css'],
})
export class CartSummaryComponent {
  @Input() totalItems: string = '';
  @Input() subTotal: number = 0;
  @Input() discount: number = 0;
  shippingCharges = 'Free';
  @Input() total: number = 0;
}
