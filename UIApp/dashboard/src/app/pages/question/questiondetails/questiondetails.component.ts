import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { QuestionService } from '../question.service';
import { Question } from '../question';

@Component({
  selector: 'app-questiondetails',
  templateUrl: './questiondetails.component.html',
  styleUrls: ['./questiondetails.component.scss']
})
export class QuestiondetailsComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc: QuestionService) {}
  questionId:number  | undefined;
  question:Question  | undefined;

  ngOnInit(): void {
  }
  
  getQuestion(questionId:number){
    this.svc.getQuestion(questionId).subscribe((res)=>{
      this.question = res;
      console.log(this.question);
    })
  }

  deleteQuestion(questionId:any){
    this.svc.deleteQuestion(questionId).subscribe((res)=>{
      this.question = res;
    })
  }

}
