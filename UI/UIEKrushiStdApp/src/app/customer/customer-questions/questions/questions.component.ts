
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit{
  constructor(
    private svc: ConsultingService,
    private usersvc:UserService,
    private router: Router,
    private route: ActivatedRoute) {}
  questions : Question[]=[];
  questionIds:any[]=[];
  data:any[]=[];
  customerid! :number;
  ngOnInit(): void {
    this.svc.getQuestions().subscribe((res)=>{
this.questions=res;
     
let customerIds=this.questions.map(u=>u.customerId);
console.log(customerIds);
 let customerIdString=customerIds.join(","); 
 this.usersvc.getUserNamesWithId(customerIdString).subscribe((res)=>{
 
  this.data=res;
  this.questions.forEach((question)=>{
    let matchingName=this.data.find((element)=>element.id==question.id)
   
    if(matchingName!=undefined){
      question.name=matchingName.name
    }
  })
 })    
    
    })

    
  }


  navigateQuestionAnswers(id:number) {
   
    this.router.navigate(['/customer/question/',id],{relativeTo:this.route});
  
    
  }

  
}
