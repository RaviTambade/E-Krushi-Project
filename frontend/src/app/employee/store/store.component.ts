import { Component, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Product } from 'src/app/product';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  products:Product[] |any;
  selectedProduct:any;

  constructor(private svc:EmployeeService,private router:Router,private route:ActivatedRoute){
    this.products=[];
  }

  ngOnInit(): void {
    this.svc.getAllProducts().subscribe((res)=>{
      this.products=res;
    })
  }

  onSelectProduct(id:any): void{
    console.log(id);
    this.router.navigate(['./details',id],{relativeTo:this.route});
  }
}



