import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-questioncategory',
  templateUrl: './questioncategory.component.html',
  styleUrls: ['./questioncategory.component.css']
})
export class QuestioncategoryComponent implements OnInit{
categories:any|[];
form: FormGroup;

category = new FormControl(null, [Validators.required]);
  constructor(private svc:ConsultingService){
    this.form = new FormGroup({
      category: this.category,
   });
  }
  ngOnInit(): void {
    this.svc.getAllQuestionCategories().subscribe((res)=>{
      this.categories=res;
      console.log(this.categories);
    })
  }

}
