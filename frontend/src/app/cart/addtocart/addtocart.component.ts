import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Item } from '../items';
import { ActivatedRoute, Route } from '@angular/router';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent implements OnInit{
  item:Item={
    productId:0,
    cartId:0,
    quantity:0,
    title:'',
    image:'',
    unitPrice:0
  }
  status:boolean |undefined;
    id:any;
  constructor(private svc:CartService,private router:Route,private route:ActivatedRoute){}
  ngOnInit(): void {
    }


public addToCart(cartForm:any){
    console.log(cartForm);
    this.id = this.route.snapshot.paramMap.get('cartid');
    console.log(this.id);
    this.svc.addToCart(cartForm).subscribe((res)=>{
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
