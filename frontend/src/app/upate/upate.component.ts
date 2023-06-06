import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-upate',
  templateUrl: './upate.component.html',
  styleUrls: ['./upate.component.css']
})
export class UpateComponent {


  constructor(private svc : ProducthubService,public fb : FormBuilder) {}
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
