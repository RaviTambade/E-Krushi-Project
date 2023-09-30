
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit{
  constructor(private svc: ConsultingService,private router: Router,private route: ActivatedRoute) {}
  questions : Question[]=[];
  questionIds:any[]=[];
  data:any[]=[];
  customerid! :number;
  ngOnInit(): void {
    this.svc.getQuestions().subscribe((res)=>{
this.questions=res;
      console.log(res);
let questionIds=this.questions.map(u=>u.id);
console.log(questionIds);
 let questionIdString=questionIds.join(","); 
 this.svc.getUser(questionIdString).subscribe((res)=>{
  console.log(res);
  this.data=res;
  this.questions.forEach((question)=>{
    let matchingName=this.data.find((element)=>element.id==question.id)
    console.log(matchingName);
    if(matchingName!=undefined){
      question.name=matchingName.name
    }
  })
 })    
    
    })

    
  }


  navigateQuestionAnswers(id:number) {
    console.log(id);
    this.router.navigate(['/customer/question/',id],{relativeTo:this.route});
  
    
  }

  
}