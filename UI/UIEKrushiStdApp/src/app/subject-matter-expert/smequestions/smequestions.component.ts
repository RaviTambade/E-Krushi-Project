import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '@services/consulting.service';

@Component({
  selector: 'app-smequestions',
  templateUrl: './smequestions.component.html',
  styleUrls: ['./smequestions.component.css']
})
export class SmequestionsComponent implements OnInit{

  constructor( private service :ConsultingService){

  }
  smeid:number=5;
  questions:any[]=[];
  ngOnInit(): void {
    this.service.getSubjectMatterExpertsSolvedQuestions(this.smeid).subscribe((response)=>{
      this.questions=response;
     
    })
  }

}
