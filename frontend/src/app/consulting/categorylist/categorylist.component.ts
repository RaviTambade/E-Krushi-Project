import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConsultingService } from '../consulting.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-categorylist',
  templateUrl: './categorylist.component.html',
  styleUrls: ['./categorylist.component.css']
})
export class CategorylistComponent {

categories:any|[];
form: FormGroup;
category = new FormControl(null, [Validators.required]);


  constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){
    this.form = new FormGroup({
      category: this.category,
   });
  }
  ngOnInit(): void {
    this.svc.getAllQuestionCategories().subscribe((res)=>{
      this.categories=res;
      console.log(this.category);
      console.log(this.categories);
    });
    // this.category.valueChanges.subscribe((category) => {
    //   this.category.reset();
    //  this.category.disable();
  //  });
    
  }
}
