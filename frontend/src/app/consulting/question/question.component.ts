import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit{

questions:any[];
  constructor(private svc:ConsultingService){
    this.questions=[];
  }

  ngOnInit(): void {
    this.svc.getAllQuestions().subscribe((res)=>{
      this.questions=res;
    })
  }
}
