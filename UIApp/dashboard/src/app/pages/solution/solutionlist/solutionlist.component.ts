import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { SolutionService } from '../solution.service';
import { Solution } from '../solution';

@Component({
  selector: 'app-solutionlist',
  templateUrl: './solutionlist.component.html',
  styleUrls: ['./solutionlist.component.scss']
})
export class SolutionlistComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc : SolutionService) {}
  
  solutions : Solution[] | undefined;

  ngOnInit(): void {
    this.svc.getAllSolutions().subscribe((res)=>{
      this.solutions=res;
      console.log(res);
  })
  }
}

