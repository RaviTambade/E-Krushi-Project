import { Component, OnInit } from '@angular/core';
import { ConsultingService } from '../consulting.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-myquestion',
  templateUrl: './myquestion.component.html',
  styleUrls: ['./myquestion.component.css']
})
export class MyquestionComponent implements OnInit{

customerQuestions:any[];
userId:any;
id:number|any;

status:Boolean=false;
  
  constructor(private svc :ConsultingService,private router:Router,private route:ActivatedRoute){
    this.customerQuestions=[]

    this.userId=localStorage.getItem("userId");
  }

  isroleCustomer():Boolean{
  let role=localStorage.getItem("role");
  if(role =="Customer" ){
    return true;
  }
  return false;
  }

  isroleSME():Boolean{
    let role=localStorage.getItem("role");
    if(role =="SubjectMatterExpert" ){
      return true;
    }
    return false;
    }
  
  ngOnInit(): void {
   this.svc.GetCustomerQuestionDetails(this.userId).subscribe((res)=>
    {
      this.customerQuestions=res;
      this.id=res.id;
      console.log(this.customerQuestions);
    })
  }

  removeQuestion(id:number){
    this.svc.removeQuestion(id).subscribe((res)=>
    { 
      console.log(res);
      if(res){
        window.location.reload();
        alert("question deleted succesfully");      
      }
      else{
        alert("while deleting error");
      }
    })
  }

  onSelectQuestion(questionId:any){
    this.router.navigate(["./answers",questionId],{relativeTo:this.route});
  }
}
