import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable, Subscription } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { ProducthubService } from '../producthub.service';

@Component({
  selector: 'app-productdetails',
  templateUrl: './productdetails.component.html',
  styleUrls: ['./productdetails.component.scss']
})
export class ProductdetailsComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc:ProducthubService) {}

subscription:Subscription |undefined;
categories : any[] | undefined;

ngOnInit():void{
  let theObservable:Observable<any> = this.svc.getData();
  this.subscription =theObservable.subscribe((msg) =>{
    this.categories = msg.data;
    console.log(msg.data);
    console.log(msg);
    console.log(" Detail Component :event handler is called")  
  });
}


}
