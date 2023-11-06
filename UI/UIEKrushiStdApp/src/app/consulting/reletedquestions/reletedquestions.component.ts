import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from '@models/question';
import { ConsultingService } from '@services/consulting.service';


@Component({
  selector: 'app-reletedquestions',
  templateUrl: './reletedquestions.component.html',
  styleUrls: ['./reletedquestions.component.css']
})
export class ReletedquestionsComponent implements OnInit{

  constructor(private svc:ConsultingService,private router:Router,private route:ActivatedRoute){}
  @Input()questionId!:number;
  reletedQuestions:Question[]=[ ];
  ngOnInit(): void {
    this.svc.getReletedQuestions(this.questionId).subscribe((response)=>{
     this.reletedQuestions= response;
     
     
    })
  }


  ngOnChanges(changes: SimpleChanges) {
    if (changes['questionId']
     ) {
      this.svc.getReletedQuestions(changes['questionId'].currentValue).subscribe((res) => {
        this.reletedQuestions = res;
      });
    }
  }



  navigateQuestionAnswers(id:number) {
   
    this.router.navigate(['/customer/question/',id],{relativeTo:this.route});
  
    
  }

}
