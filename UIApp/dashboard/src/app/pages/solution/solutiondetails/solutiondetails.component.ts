import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { SolutionService } from '../solution.service';
import { Solution } from '../solution';

@Component({
  selector: 'app-solutiondetails',
  templateUrl: './solutiondetails.component.html',
  styleUrls: ['./solutiondetails.component.scss']
})
export class SolutiondetailsComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc:SolutionService) {}
  solutionId:number | undefined;
  solution : Solution |undefined;

  ngOnInit(): void {
  }

  getSolution(solutionId:number){
    this.svc.getSolution(solutionId).subscribe((res)=>{
      this.solution=res;
    });
  }

  deleteSolution(solutionId:any){
    this.svc.deleteSolution(solutionId).subscribe((res)=>{
      this.solution = res;
    })
   }
  
}
