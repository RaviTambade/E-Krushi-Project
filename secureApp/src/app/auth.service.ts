import { Injectable } from '@angular/core';

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
      'email':'Rushikesh.C@gmail.com',
      'password':'password',
      'role':'Customer'
    },
    {
      'email':'Akash.A@gmail.com',
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

  constructor() { }
}
