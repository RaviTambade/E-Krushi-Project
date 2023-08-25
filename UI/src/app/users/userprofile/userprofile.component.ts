import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';
import { User } from '../user';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css']
})
export class UserprofileComponent implements OnInit{

userId:any;
userProfile:any;

constructor(private svc:UsersService,private router:Router,private route:ActivatedRoute){
  this.userId=localStorage.getItem("userId");
}

ngOnInit(): void {
  console.log(this.userId);
  this.svc.userProfile(this.userId).subscribe((res)=>{
    this.userProfile=res;
    console.log(this.userProfile);
  })
}

gotoprofile(){
  this.router.navigate(['editprofile'],{relativeTo:this.route});
}

// onSelectProduct(id:any){
//   console.log(id);
//   this.router.navigate(["details",id],{relativeTo:this.route});
// }

}
