import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { PagesserviceService } from '../pagesservice.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  user : User ={email:'',
                password:'',
                contactNumber:''}
  status : boolean  | undefined

  constructor(private svc : PagesserviceService) { }

  ngOnInit() {

  }

  Register(user:User){
    console.log(user);
    this.svc.Register(user).subscribe((response)=>{
      this.status = response;
      console.log(response);
      
      if(response){
        alert("Registration sucessfull")
        window.location.reload();
      }
      else
      {
        alert("Registration failed")
      }
    })

  }

}
