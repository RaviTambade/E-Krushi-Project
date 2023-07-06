import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-questionanswer',
  templateUrl: './questionanswer.component.html',
  styleUrls: ['./questionanswer.component.css']
})
export class QuestionanswerComponent implements OnInit{

  questions:any[] ;
  questionId:number |any;
  constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){
    this.questions=[];
  }
  
  ngOnInit(): void {
    this.questionId=this.route.snapshot.paramMap.get('questionId');
    console.log(this.questionId);
    this.svc.getCustomerQuestionAnswer(this.questionId).subscribe((res)=>{
      this.questions=res;
  })
  }
}
