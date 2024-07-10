import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Question } from '@models/question';
import { ConsultingService } from '@services/consulting.service';

@Component({
  selector: 'app-categorywisequestions',
  templateUrl: './categorywisequestions.component.html',
  styleUrls: ['./categorywisequestions.component.css']
})
export class CategorywisequestionsComponent implements OnInit {

  constructor(private svc:ConsultingService,private route:ActivatedRoute,private router:Router){}
  questions:Question[]=[]
  categoryId!:number
  category:string=''
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.categoryId=params["categoryId"]
    })
    this.svc.getCategorywiseQuestions(this.categoryId).subscribe((res)=>{
      this.questions=res;
     
    })
  }

  navigateQuestionAnswers(id:number) {
   
    this.router.navigate(['/crm/question/',id],{relativeTo:this.route});
  
    
  }

}
