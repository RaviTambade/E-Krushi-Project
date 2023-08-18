import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Credential } from '../Credential';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
userId:number |any;
roles:any[];
status:boolean=false;

  credential: Credential = {
    contactNumber: '',
    password: ''
  }

  constructor(private svc: AuthenticationService,private router:Router) {
    // this.productId=localStorage.getItem("")
    this.roles=[];
    this.status=true;
   }

  onLogin(form: any) {
    console.log(form);
    this.svc.validate(form).subscribe((response) => {
      console.log(response);
      localStorage.setItem("contactNumber",this.credential.contactNumber);
      localStorage.setItem("jwt",response.token)
    })
    this.svc.getUserId(this.credential.contactNumber).subscribe((response)=>{
      this.userId=response;
      console.log(this.userId);
      localStorage.setItem("userId",this.userId);
      this.svc.getRolesOfUser(this.userId).subscribe((res)=>{
        this.roles=res;
        console.log(this.roles);
       
       
        if(this.roles?.length==1){
        const role=this.roles[0];
        this.navigateByRole(role);
       }

       if(this.roles?.length< 1){
      //  const role=this.roles;
       } 
       })
     }) 
  }

  navigateByRole(role:string){
    localStorage.setItem("role",role);
     switch (role){
     case "Customer":
     this.router.navigate(['home']);
     break;

    case 'Shop owner':
    this.router.navigate(['register']);
    break;
  }
  }


  onFormSubmit(){
    return this.roles.length < 1;
  }
 }
