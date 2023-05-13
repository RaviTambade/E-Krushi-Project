import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CategoryService } from '../category.service';
import { Category } from '../category';

@Component({
  selector: 'app-categorydetails',
  templateUrl: './categorydetails.component.html',
  styleUrls: ['./categorydetails.component.scss']
})
export class CategorydetailsComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
   

  categoryId:number |undefined;
  category:Category |undefined;
  constructor(private breakpointObserver: BreakpointObserver,private svc:CategoryService) {}
  ngOnInit(): void {
    
  }
  getCategory(categoryId:number){
    this.svc.getCategoryDetails(categoryId).subscribe((Response=>{
      this.category= Response;
      console.log(this.category);
    }))
 }

 deleteCategory(categoryId:any){
  this.svc.deleteCategory(categoryId).subscribe((res)=>{
    this.category = res;
  })
 }
}
