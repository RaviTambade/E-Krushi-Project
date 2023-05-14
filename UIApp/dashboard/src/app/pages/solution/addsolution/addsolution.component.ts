import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { SolutionService } from '../solution.service';
import { Solution } from '../solution';

@Component({
  selector: 'app-addsolution',
  templateUrl: './addsolution.component.html',
  styleUrls: ['./addsolution.component.scss']
})
export class AddsolutionComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc: SolutionService) {}

  solution:Solution={
    solutionId:0,
    description:''
  }

  ngOnInit(): void {
  }

  addSolution(solution:Solution){
    this.svc.addSolution(solution).subscribe((res)=>{
      this.solution=res;
      if(res){
        alert("solution inserted successfully");
        window.location.reload();
      }
      else{
        alert("error")
      }
    })
  }

}
