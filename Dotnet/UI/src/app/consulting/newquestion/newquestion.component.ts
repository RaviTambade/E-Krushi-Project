import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { Question } from '../Question';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-newquestion',
  templateUrl: './newquestion.component.html',
  styleUrls: ['./newquestion.component.css']
})
export class NewquestionComponent implements OnInit {
  question:Question={
    id: 0,
    description: '',
    categoryId: 0
  };
 categoryId:any|number;

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
    this.category.valueChanges.subscribe((category) => {
      // this.category.reset();
    //  this.category.disable();
     if(category){
    this.svc.getCategoryId(category).subscribe((res)=>{
      this.categoryId=res;
     console.log(this.categoryId);
      })
  }
  });
}

  

  


  insertQuestion(form:any){
    this.svc.insertQuestion(form).subscribe((res)=>{
      this.question=res;
    })
  }
}
