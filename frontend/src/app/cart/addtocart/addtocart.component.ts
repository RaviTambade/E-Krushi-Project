import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Item } from '../items';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent implements OnInit{
  item:Item={
    productId:1,
    cartId:1,
    quantity:0
  }
  status:boolean |undefined;
    id:any;
  constructor(private svc:CartService,private router:Router,private route:ActivatedRoute){}
  ngOnInit(): void {
    }


public addToCart(item:Item){
    console.log(item);
    this.id = this.route.snapshot.paramMap.get('id');
    console.log(this.id);
    this.svc.addToCart(item).subscribe((res)=>{
    this.status=res;
    // console.log(this.item)
    // if(res){
    //   window.location.reload();
    //   alert("Record Inserted Successfully");
    // }
    // else{
    //   alert("Error While Inserting Record")
    // }
    });
  }
}
