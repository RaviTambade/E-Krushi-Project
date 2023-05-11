import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { PagesserviceService } from '../pagesservice.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

    constructor(private breakpointObserver: BreakpointObserver,private svc : PagesserviceService) {}
    productId : any
    ngOnInit(): void {
      }

    getProduct(productId:number){
    this.svc.getProduct(productId).subscribe((response)=>{
      this.productId=response;
      console.log(response);
    
  }
   );
    // onClick(productId:any){
  
    // }
  
  }
}