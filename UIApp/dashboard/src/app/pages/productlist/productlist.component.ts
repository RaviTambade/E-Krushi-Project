import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { PagesserviceService } from '../pagesservice.service';
import { Product } from '../product';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.scss']
})
export class ProductlistComponent implements OnInit {
  products : Product[] | undefined;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc : PagesserviceService) {}
  ngOnInit(): void {
    this.svc.getAllProducts().subscribe((response)=>{
      this.products=response;
      console.log(response);
  }
   );
  }
  // onClick(productId:any){

  // }

}
