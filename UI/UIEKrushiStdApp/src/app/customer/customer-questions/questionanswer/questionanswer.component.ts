import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/Models/question';
import { QuestionAnswer } from 'src/app/Models/questionanswer';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-questionanswer',
  templateUrl: './questionanswer.component.html',
  styleUrls: ['./questionanswer.component.css']
})
export class QuestionanswerComponent implements OnInit {
  constructor(private svc: ConsultingService) {}
  questionsAnswers : QuestionAnswer[]=[];
  question:string='';
  id:number=1;
  ngOnInit(): void {
    this.svc.getAnswers(this.id).subscribe((res)=>{
      this.questionsAnswers=res;
      this.question=this.questionsAnswers[0].question;
      console.log(res);

    })
  }
}
