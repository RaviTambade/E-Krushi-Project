import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-reletedquestions',
  templateUrl: './reletedquestions.component.html',
  styleUrls: ['./reletedquestions.component.css']
})
export class ReletedquestionsComponent implements OnInit{

  constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){}
  @Input()questionId!:number;
  reletedQuestions:Question[]=[ ];
  ngOnInit(): void {
    this.svc.getReletedQuestions(this.questionId).subscribe((response)=>{
     this.reletedQuestions= response;
      console.log(this.questionId)
      console.log(response);
    })
  }



  navigateQuestionAnswers(id:number) {
    console.log(id);
    this.router.navigate(['/customer/question/',id],{relativeTo:this.route});
  
    
  }

}
