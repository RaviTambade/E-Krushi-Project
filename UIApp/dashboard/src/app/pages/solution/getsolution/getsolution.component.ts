import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { SolutionService } from '../solution.service';
import { Solution } from '../solution';

@Component({
  selector: 'app-getsolution',
  templateUrl: './getsolution.component.html',
  styleUrls: ['./getsolution.component.scss']
})
export class GetsolutionComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc:SolutionService) {}
  @Input () solutionId:number |undefined;
  solution:Solution |undefined;
  @Output() sendSolution = new EventEmitter();
  ngOnInit(): void {
  }

  getSolution(solutionId:any){
    this.svc.getSolution(solutionId).subscribe((res)=>{
      this.solution=res;
      this.sendSolution.emit({solution:this.solution});
    })
  }

}
