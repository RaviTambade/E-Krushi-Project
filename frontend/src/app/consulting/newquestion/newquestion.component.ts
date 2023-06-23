import { Component } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { Question } from '../Question';

@Component({
  selector: 'app-newquestion',
  templateUrl: './newquestion.component.html',
  styleUrls: ['./newquestion.component.css']
})
export class NewquestionComponent {

  question:Question={
    id: 0,
    description: '',
    categoryId: 0
  };
  categoryId:number=2;

  constructor(private svc:ConsultingService){}

  insertQuestion(form:any){
    this.svc.insertQuestion(form).subscribe((res)=>{
      this.question=res;
    })
  }
}
