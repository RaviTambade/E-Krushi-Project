import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CrmService } from '../crm.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-getcustomer',
  templateUrl: './getcustomer.component.html',
  styleUrls: ['./getcustomer.component.scss']
})
export class GetcustomerComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  @Input() custId:number |undefined;
  customer:Customer |undefined;
  @Output() sendCustomer = new EventEmitter();
  constructor(private breakpointObserver: BreakpointObserver,private svc :CrmService) {}
  
  
  ngOnInit(): void {
    }
    
  getCustomer(custId:any){
    this.svc.getCustomer(custId).subscribe((response)=>{
      this.customer=response;
      this.sendCustomer.emit({customer:this.customer});
      console.log(this.customer);
    })
  }


}


