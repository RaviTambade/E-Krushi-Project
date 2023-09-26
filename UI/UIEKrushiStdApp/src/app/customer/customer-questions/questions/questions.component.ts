
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit{
  constructor(private svc: ConsultingService,private router: Router,private route: ActivatedRoute) {}
  questions : Question[]=[];
  
  ngOnInit(): void {
    this.svc.getQuestions().subscribe((res)=>{
this.questions=res;
      console.log(res);

    })

    
  }


  navigateQuestionAnswers(id:number) {
    console.log(id);
    this.router.navigate(['/customer/question/',id],{relativeTo:this.route});
  
    
  }

  
}
