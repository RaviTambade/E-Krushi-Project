import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-questioncategory',
  templateUrl: './questioncategory.component.html',
  styleUrls: ['./questioncategory.component.css']
})
export class QuestioncategoryComponent implements OnInit{
categories:any|[];
form: FormGroup;
questions:any|[];
category = new FormControl(null, [Validators.required]);
 question= new FormControl(null, [Validators.required]);

  constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){
    this.form = new FormGroup({
      category: this.category,
      question:this.question
   });
  }
  ngOnInit(): void {
    this.svc.getAllQuestionCategories().subscribe((res)=>{
      this.categories=res;
      console.log(this.categories);
    });
    this.category.valueChanges.subscribe((category) => {
      this.question.reset();
     // this.product.disable();
      if (category) {
        this.svc.getAllQuestionsByCategory(category).subscribe((response)=>{
         this.questions=response;
         console.log(this.questions);
        })
        this.questions.enable();
       }
   });
    
  }


  onSelectQuestion(id:any){
    console.log(id);
    this.router.navigate(["details",id],{relativeTo:this.route});
  }

}
