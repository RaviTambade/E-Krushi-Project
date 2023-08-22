import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css']
})
export class UserprofileComponent implements OnInit{

userId:any;
user:any;

constructor(private svc:UsersService){}
ngOnInit(): void {
  this.svc.userProfile(this.userId).subscribe((res)=>{
    this.user=res;
  })
}


 





}
