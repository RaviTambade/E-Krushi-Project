import { Component } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-productdetails',
  templateUrl: './productdetails.component.html',
  styleUrls: ['./productdetails.component.css']
})
export class ProductdetailsComponent {

  product: any;
  id:any; 
  unitPrice:any;
  category:any;
  //set full object in localstorage instead of setting one by one
  constructor(private svc:ProductService,private route:ActivatedRoute,private router:Router){
    this.category =localStorage.getItem("category");
  }
  
  ngOnInit(): void {
    console.log(this.category);
    console.log("ng on init")
    this.id = this.route.snapshot.paramMap.get('id');
    console.log(this.id);
    this.svc.getById(this.id).subscribe((res)=>{
    this.product=res;
    localStorage.setItem("product",res.product);
    localStorage.setItem("price",res.unitPrice);
    localStorage.setItem("title",res.title);
    localStorage.setItem("image",res.image);
    localStorage.setItem("productId",res.id);
    console.log(this.product);
    });
}

    onClick(id:any){
      this.router.navigate(['./addtocart',id],{relativeTo:this.route})
    }
}
