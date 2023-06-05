import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CategoryService } from '../category.service';
import { Category } from '../category';

@Component({
  selector: 'app-addcategory',
  templateUrl: './addcategory.component.html',
  styleUrls: ['./addcategory.component.scss']
})
export class AddcategoryComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );


  constructor(private breakpointObserver: BreakpointObserver,private svc :CategoryService) {}
  category:Category={
   Id:0,
   Title:'',
   description:'',
   image:''
}

  ngOnInit(): void {
  }
  
  addCategory(form:any){
    this.svc.addCategory(form).subscribe((res)=>{
      this.category=res;
    })
  }
}
