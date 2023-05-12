import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Customer } from '../customer';
import { CrmService } from '../crm.service';

@Component({
  selector: 'app-insertcustomer',
  templateUrl: './insertcustomer.component.html',
  styleUrls: ['./insertcustomer.component.scss']
})
export class InsertcustomerComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc :CrmService) {}
  ngOnInit(): void {

  }

  customer:Customer={
    custId:0,
    firstName :'',
    lastName :'',
    userId :0
  }

  insertCustomer(form:any){
    this.svc.insertCustomer(form).subscribe((res)=>{
      this.customer=res;
      console.log(this.customer);
      if(res){
        alert("customer inserted successfully");
        window.location.reload();
      }
      else{
        alert("error")
      }
      console.log(res);
    }
    );
  }
  

}
