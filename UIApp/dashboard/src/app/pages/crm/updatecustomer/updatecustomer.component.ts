import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CrmService } from '../crm.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-updatecustomer',
  templateUrl: './updatecustomer.component.html',
  styleUrls: ['./updatecustomer.component.scss']
})
export class UpdatecustomerComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc:CrmService) {}
  customer:Customer |any;
  custId: any;
  status:boolean |undefined;
  ngOnInit(): void {
    
  }
  updateCustomer(){
    this.svc.updateCustomer(this.customer).subscribe((response)=>{
      this.status = response;
      console.log(this.customer);
    });
  }
  receiveCustomer($event:any){
    this.customer=$event.customer;
  }

}
