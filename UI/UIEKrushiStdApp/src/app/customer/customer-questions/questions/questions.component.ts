import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit{
  constructor(private svc: ConsultingService,private router: Router) {}
  questions : Question[]=[];
  questionId! :number;
  ngOnInit(): void {
    this.svc.getQuestions().subscribe((res)=>{
this.questions=res;
      console.log(res);

    })
  }

  
}
