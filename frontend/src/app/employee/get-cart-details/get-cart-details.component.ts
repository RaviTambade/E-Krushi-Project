import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-get-cart-details',
  templateUrl: './get-cart-details.component.html',
  styleUrls: ['./get-cart-details.component.css']
})
export class GetCartDetailsComponent {


  @Input () categoryId:number |undefined;
  category:any | undefined;
  @Output () sendCategory=new EventEmitter();

  getCategory(categoryId:number){
    this.svc.getCategoryDetails(categoryId).subscribe((Response=>{
      this.category= Response;
      this.sendCategory.emit({category:this.category});
    }))
 }

}
