import { Component, Input } from '@angular/core';
import { OrderedItem } from 'src/app/Models/orderdItem';

@Component({
  selector: 'app-order-product-details',
  templateUrl: './order-product-details.component.html',
  styleUrls: ['./order-product-details.component.css']
})
export class OrderProductDetailsComponent {
 @Input() item!:OrderedItem; 
}
