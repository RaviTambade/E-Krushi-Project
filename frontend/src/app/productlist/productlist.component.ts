import { Component } from '@angular/core';
import { ProducthubService } from '../producthub.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent {

  constructor(){private svc:ProducthubService,public fb:Formbuilder}
  isSubmitted=false;
  products =['','',]

}
