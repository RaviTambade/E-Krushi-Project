import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CategoryService } from '../category.service';
import { Category } from '../category';

@Component({
  selector: 'app-updatecategory',
  templateUrl: './updatecategory.component.html',
  styleUrls: ['./updatecategory.component.scss']
})
export class UpdatecategoryComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc: CategoryService) {}
  ngOnInit(): void {
  }
  
  category:Category | any ;
  categoryId : any;
  status : boolean | undefined;

  updateCategory(){
    this.svc.updateCategory(this.category).subscribe((res)=>{
      this.category=res;
      if(res){
        alert("customer updated successfully");
        window.location.reload();
      }
      else{
        alert("error")
      }
    });
  }

  receiveCategory($event:any){
    this.category=$event.category;
  }
}
