import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';

@Component({
  selector: 'app-myquestion',
  templateUrl: './myquestion.component.html',
  styleUrls: ['./myquestion.component.css']
})
export class MyquestionComponent implements OnInit{

customerQuestions:any[];
custId:any=2;

  
  constructor(private svc :ConsultingService){
    this.customerQuestions=[]
  }
  
  ngOnInit(): void {
   this.svc.GetCustomerQuestionDetails(this.custId).subscribe((res)=>
    {
      this.customerQuestions=res;
    })
  
  }

}