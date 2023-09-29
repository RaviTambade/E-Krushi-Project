import { Component, Input, OnInit } from '@angular/core';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-reletedquestions',
  templateUrl: './reletedquestions.component.html',
  styleUrls: ['./reletedquestions.component.css']
})
export class ReletedquestionsComponent implements OnInit{

  constructor(private svc:ConsultingService){}
  @Input()questionId!:number;
  reletedQuestions:Question[]=[ ];
  ngOnInit(): void {
    this.svc.getReletedQuestions(this.questionId).subscribe((response)=>{
     this.reletedQuestions= response;
      console.log(this.questionId)
      console.log(response);
    })
  }

}
