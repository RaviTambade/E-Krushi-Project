import { Component, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Product } from 'src/app/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  products:Product[] |any;
  @Input() id:any ;

  constructor(private svc:EmployeeService,private router:Router){}

  ngOnInit(): void {
    this.svc.getAllProducts().subscribe((res)=>{
      this.products=res;
    })
  }

  onSelectProduct(id:any){
    console.log(id);
    this.router.navigate(['./details',id])
  }
}
