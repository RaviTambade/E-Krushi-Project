import { Injectable } from '@angular/core';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  users : User []=[
    {
      'email':'Pragati.B@gmail.com',
      'password':'password',
      'role':'Admin'
    },
    {
      'email':'Rushikesh',
      'password':'password',
      'role':'Customer'
    },
    {
      'email':'Akash',
      'password':'password',
      'role':'Employee'
    },
    {
      'email':'Akashay.T@gmail.com',
      'password':'password',
      'role':'Employee'
    },
    {
      'email':'Rohit.G@gmail.com',
      'password':'password',
      'role':'Customer'
    },
  ]

  isLogin = false;
  loggedIn:any;
  constructor() { }

  logIn(email:string,password:string,role:string):boolean{
    const user=this.users.find((u)=>u.email ===email && u.password===password)
    if(user){
      this.loggedIn=user;
      localStorage.setItem("role",user.role)
      return true;
    }
    return false;
  }
}
