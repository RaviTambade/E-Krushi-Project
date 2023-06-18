import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css']
})
export class RemoveComponent implements OnInit {
productId:any;

  constructor(private svc :EmployeeService,private router:Router,private route:ActivatedRoute){}
  ngOnInit(): void {
    this.productId = this.route.snapshot.paramMap.get('id');
    this.svc.removeFromCart(this.productId).subscribe((res)=>{
      this.productId=res;
      console.log(this.productId);
     }) 
  }
}

