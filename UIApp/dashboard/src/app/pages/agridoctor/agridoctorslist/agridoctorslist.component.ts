import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AgridoctorService } from '../agridoctor.service';
import { AgriDoctor } from './agridoctor';

@Component({
  selector: 'app-agridoctorslist',
  templateUrl: './agridoctorslist.component.html',
  styleUrls: ['./agridoctorslist.component.scss']
})
export class AgridoctorslistComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc :AgridoctorService) {}

  agriDoctors:AgriDoctor |undefined;

  ngOnInit(): void {
    this.svc.getAllAgriDoctors().subscribe((res)=>{
      this.agriDoctors=res;
      console.log(res);
    });
  }

}
