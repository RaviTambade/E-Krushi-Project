import { Component, OnInit } from '@angular/core';
import { CustomerQuestion } from '../customerquestion';
import { ConsultingService } from '../consulting.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-addquestion',
  templateUrl: './addquestion.component.html',
  styleUrls: ['./addquestion.component.css']
})
export class AddquestionComponent implements OnInit{
   question:CustomerQuestion={
     id: 0,
     questionId: 0,
     customerId: 0,
     questionDate: ''
   };
   questionId:any;
   customerId:number=2;
  questionName:any;
  constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){
    this.questionName=localStorage.getItem("question");
  }
  ngOnInit(): void {
   this.questionId=this.route.snapshot.paramMap.get('id');
  }
 
 insertCustomerQuestion(form:any){
  console.log(form);
       this.svc.insertCustomerQuestion(form).subscribe((res=>{
      this.question=res;


      if(res){
        window.location.reload();
        alert("question added succesfully");
        
      }
      else{
        alert("while inserting error");
      }
    }))
    
  }

}
