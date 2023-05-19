import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { ProducthubService } from '../producthub.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-getproductlistbycategory',
  templateUrl: './getproductlistbycategory.component.html',
  styleUrls: ['./getproductlistbycategory.component.scss']
})
export class GetproductlistbycategoryComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
  

  constructor(private breakpointObserver: BreakpointObserver,private svc : ProducthubService,public fb : FormBuilder) {}
  isSubmitted = false;
  categories= ['seeds','agriculture equipments','fertilizers','pesticides','agricultural sprayers','plants micronutrients'] ;

  ngOnInit(): void {}
  registrationForm = this.fb.group({

    selectedCategory : [ ' ', [Validators.required]],
      
    });
    changeCategory(e: any){
      this.selectedCategory?.setValue(e.target.value,{
       onlySelf : true,
      });
}

      get selectedCategory(){

       return this.registrationForm.get('selectedCategory');
        
      }

      onSubmit ():void {

        console.log(this.registrationForm);
        
        this.isSubmitted= true;
        
        if(!this.registrationForm.valid){
        
        false;
        
        }
        
        else{
        
        console.log(JSON.stringify(this.registrationForm.value));
        
        this.svc.sendCategory(this.registrationForm.value);
        
        }
        
        }
}


