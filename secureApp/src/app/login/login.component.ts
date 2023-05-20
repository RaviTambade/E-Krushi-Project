import { Component ,OnInit} from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  email:string | any;
  password:string | any;
  role : string | any
  loggedIn :any;
  
  constructor(private svc :AuthService){}

  ngOnInit():void{
  }
  
  onLogin(form:any){
    console.log(form);
    if(this.svc.logIn(this.email,this.password,this.role)){
      alert("login successfull");
      this.loggedIn = true; 
    }
    else{
      alert("login failed");
    }

  }

}
