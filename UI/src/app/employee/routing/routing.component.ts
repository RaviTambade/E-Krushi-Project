import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-routing',
  templateUrl: './routing.component.html',
  styleUrls: ['./routing.component.css']
})
export class RoutingComponent {

  constructor(private router: Router) { }
    isroleshopowner(): boolean {
    const role = localStorage.getItem("role")
    return role == 'Shop owner';
  }

  isroleseller(): boolean {
    const role = localStorage.getItem("role")
    return role == 'seller';
  }

  isrolecustomer(): boolean {
    const role = localStorage.getItem("role")
    return role == 'Customer';
  }
  isroleshipper(): boolean {
    const role = localStorage.getItem("role")
    return role == 'shipper';
  }

  isroleSME(): boolean {
    const role = localStorage.getItem("role")
    return role == 'SubjectMatterExpert';
  }

//   openUserProfile() {
//     this.router.navigate(['userinfo']);
// }

// isUser():boolean{
//   const userId = localStorage.getItem("userId")
//   if (userId != null) {
//     return true;
//   }
//   return false;
// }

// isLoggedIn():boolean{
//   const jwt =localStorage.getItem("jwt")
//   if (jwt != null) {
//     return false;
//   }
//   return true;
// }
// loggedOut(){
//   this.router.navigate(['userlogout']);
// }

}
