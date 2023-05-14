import { Component, Input, Output,EventEmitter } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CategoryService } from '../category.service';

@Component({
  selector: 'getcategory',
  templateUrl: './getcategory.component.html',
  styleUrls: ['./getcategory.component.scss']
})
export class GetcategoryComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc:CategoryService) {}
  
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
