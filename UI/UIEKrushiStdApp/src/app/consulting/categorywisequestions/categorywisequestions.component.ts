import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-categorywisequestions',
  templateUrl: './categorywisequestions.component.html',
  styleUrls: ['./categorywisequestions.component.css']
})
export class CategorywisequestionsComponent implements OnInit {

  constructor(private svc:ConsultingService){}
  questions:Question[]=[]
  category!:string
  ngOnInit(): void {
    this.svc.getCategorywiseQuestions(this.category).subscribe((res)=>{
      this.questions=res;
      console.log(res);
    })
  }

}
