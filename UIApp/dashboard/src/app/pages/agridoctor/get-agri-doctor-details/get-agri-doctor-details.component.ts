import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AgridoctorService } from '../agridoctor.service';
import { AgriDoctor } from '../agridoctor';

@Component({
  selector: 'app-get-agri-doctor-details',
  templateUrl: './get-agri-doctor-details.component.html',
  styleUrls: ['./get-agri-doctor-details.component.scss']
})
export class GetAgriDoctorDetailsComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,private svc : AgridoctorService) {}

agridoctorId:number|undefined;

 agridoctor:AgriDoctor|undefined;



  ngOnInit(){
    
  }





  getAgriDoctorDetails(agriDoctorId:number){
    this.svc.getAgriDoctorDetails(agriDoctorId).subscribe((Response=>{
      this.agridoctorId= Response;
      console.log(this.agridoctorId);
    }));
 }

}
