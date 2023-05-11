import { Component, Input, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CrmService } from '../crm.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-customerdetails',
  templateUrl: './customerdetails.component.html',
  styleUrls: ['./customerdetails.component.scss']
})
export class CustomerdetailsComponent implements OnInit {

   custId : number |undefined;
   customer:Customer |undefined;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc :CrmService) {}
  ngOnInit(): void {
    
  }



 public getCustomer(custId:number){

    this.svc.getCustomer(custId).subscribe((Response)=>{

      this.customer=Response;
      console.log(Response);
    });
  }

}
