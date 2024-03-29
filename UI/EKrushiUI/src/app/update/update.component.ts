import { Component } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { ProductService } from '../product/product.service';


@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
  
  constructor(private svc:ProductService) {}

  subscription:Subscription |undefined;
  product : any | undefined;
  
  ngOnInit():void{
    let theObservable:Observable<any> = this.svc.getData();
    this.subscription =theObservable.subscribe((msg) =>{
      this.product = msg.data;
      console.log(msg.data);
      console.log(msg);
      console.log(" Detail Component :event handler is called")  
    });
}
}