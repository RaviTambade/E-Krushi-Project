
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
  customerid! :number;
  ngOnInit(): void {
    this.svc.getQuestions().subscribe((res)=>{
this.questions=res;
      console.log(res);

      if (this.questions.length > 0) {
        this.customerid = this.questions[0].customerId; // Assuming 'id' is a property in the response objects
      }

      if (this.customerid) {

        console.log(this.customerid);
        // this.dataService.getDataById(this.extractedId).subscribe((secondResponse) => {
        //   this.secondResponseData = secondResponse;
        // });
      }

    })

    
  }


  navigateQuestionAnswers(id:number) {
    console.log(id);
    this.router.navigate(['/customer/question/',id],{relativeTo:this.route});
  
    
  }

  
}
