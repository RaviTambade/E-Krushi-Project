import { Component, OnInit } from '@angular/core';
import { ProducthubService } from '../producthub.service';
import { Product } from '../product';

@Component({
  selector: 'app-productgrid',
  templateUrl: './productgrid.component.html',
  styleUrls: ['./productgrid.component.css']
})
export class ProductgridComponent implements OnInit {
products:Product[] |undefined

  constructor(private svc:ProducthubService){}

  ngOnInit(): void {
    this.svc.getAllProducts().subscribe((res)=>{
      this.products=res;
    })
  }
}
