import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Product } from '../product';
import { ProducthubService } from '../producthub.service';

@Component({
  selector: 'app-newproduct',
  templateUrl: './newproduct.component.html',
  styleUrls: ['./newproduct.component.scss']
})
export class NewproductComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc:ProducthubService) {}

  product:Product={
    id:0,
    title:' ',
    unitPrice:0,
    stockAvailable:0,
    image:' ',
    categoryId:0
  }

  status:boolean |undefined;

  insertProduct(form:any){
    this.svc.insertProduct(form).subscribe(
      (res)=>{
        this.status = res;
        console.log(this.product);
        console.log(res);
      if(res){
        window.location.reload();
        alert("Record Inserted Successfully");
      }
      else{
        alert("Error While Inserting Record")
      }
    })
  }
}
