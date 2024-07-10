import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit{

questions:any[];
id:any;


  constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){
    this.questions=[];
  }

  ngOnInit(): void {
    this.svc.getAllQuestions().subscribe((res)=>{
      this.questions=res;
      console.log(this.questions);
    })
    
  }

  onSelectQuestion(id:any){
    this.router.navigate(["./detail",id],{relativeTo:this.route});
    
  }

  onNewQuestion(){
    this.router.navigate(["./newquestion"],{relativeTo:this.route})
   }
}
