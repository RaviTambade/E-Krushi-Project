import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';
import { User } from '../user';
import { Location } from '../location';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit{
  
  userId:any;
  status:boolean |undefined;
  userProfile:any;
  constructor(private svc :UsersService){
    this.userId=localStorage.getItem("userId");
  }
 
  ngOnInit(): void {
    this.svc.userProfile(this.userId).subscribe((res)=>{
      // this.userProfile=res;
      
      this.location=res.location;
      this.user=res.user;
    })
  }

  location:Location={ 
    id:0,
    userId:0,
    longitude:'',
    latitude:'',
    landMark:'',
    pinCode:'' 
  }

  user:User={
    id: 0,
    imageUrl: '',
    firstName: '',
    lastName: '',
    birthDate: '',
    aadharId: '',
    gender: '',
    email: '',
    contactNumber: ''
  }

  public editUserProfile(form:any){
    this.svc.editUserProfile(this.userId,this.user).subscribe((res)=>{
      this.status=res;
    })
  }

  public editLocationProfile(form:any){
    this.svc.editLocationProfile(this.userId,this.location).subscribe((res)=>{
      this.status=res;
    })
  }
}
