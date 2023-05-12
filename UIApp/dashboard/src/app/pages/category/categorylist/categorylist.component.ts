import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CategoryService } from '../category.service';
import { Category } from '../category';

@Component({
  selector: 'app-categorylist',
  templateUrl: './categorylist.component.html',
  styleUrls: ['./categorylist.component.scss']
})
export class CategorylistComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

    ngOnInit(): void {
    }
  constructor(private breakpointObserver: BreakpointObserver,private svc: CategoryService) {}
  categories : Category[]  |undefined;

  

  getAllCategories(){
    console.log("category");
    this.svc.getAllCategories().subscribe((res)=>{
      this.categories=res;
      console.log(res);
    });
  }
}
