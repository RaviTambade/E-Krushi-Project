import { Component, OnInit } from '@angular/core';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-unsolvedquestions',
  templateUrl: './unsolvedquestions.component.html',
  styleUrls: ['./unsolvedquestions.component.css']
})
export class UnsolvedquestionsComponent implements OnInit{
  smeid:number=40;
  questions:any[]=[];
  constructor(private service:ConsultingService){}
  ngOnInit(): void {
     this.service.getUnSolvedQuestions(this.smeid).subscribe((response)=>{
      this.questions=response;
     
     })
  }

}
