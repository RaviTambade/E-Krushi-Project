import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Product } from 'src/app/product';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  products:Product[] |any;
  constructor(private svc:EmployeeService){}

  ngOnInit(): void {
    this.svc.getAllProducts().subscribe((res)=>{
      this.products=res;
    })
  }

}
