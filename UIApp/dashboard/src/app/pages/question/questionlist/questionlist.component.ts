import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { QuestionService } from '../question.service';
import { Question } from '../question';

@Component({
  selector: 'app-questionlist',
  templateUrl: './questionlist.component.html',
  styleUrls: ['./questionlist.component.scss']
})
export class QuestionlistComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );


  constructor(private breakpointObserver: BreakpointObserver,private svc:QuestionService) {}
  questions:Question[] | undefined;
  
  
  ngOnInit(): void {
    this.svc.getAllQuestions().subscribe((res)=>{
      this.questions = res;
      console.log(this.questions);
  });
  }
}
