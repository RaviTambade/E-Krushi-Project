import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { SolutionService } from '../solution.service';
import { Solution } from '../solution';

@Component({
  selector: 'app-updatesolution',
  templateUrl: './updatesolution.component.html',
  styleUrls: ['./updatesolution.component.scss']
})
export class UpdatesolutionComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc:SolutionService) {}
  solution:Solution |any;
  solutionId: any;
  ngOnInit(): void {
  }

  updateSolution(){
    this.svc.updateSolution(this.solution).subscribe((res)=>{
      this.solution=res;
      if(res){
        alert("solution updated successfully");
        window.location.reload();
      }
      else{
        alert("error")
      }
    })
  }

  receiveSolution($event:any){
    this.solution=$event.solution;
  }


}
