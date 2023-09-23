import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit{
  constructor(private svc: ConsultingService) {}
  questions : Question[]=[];
  ngOnInit(): void {
    this.svc.getQuestions().subscribe((res)=>{
      this.questions=res;

    })
  }
}
