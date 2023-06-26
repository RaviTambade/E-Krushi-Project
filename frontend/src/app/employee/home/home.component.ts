import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/product';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
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
