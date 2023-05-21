import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-routing',
  templateUrl: './routing.component.html',
  styleUrls: ['./routing.component.css']
})
export class RoutingComponent implements OnInit {
 
  role=localStorage.getItem("role");
  statusAkash=false;
  statusRushikesh=false;
 
 
 
  ngOnInit(): void {
    

    if (this.role=="employee"){
      this.statusAkash=true;
      this.statusAkash=true;
    }
    else{
      this.statusRushikesh=false;
      this.statusRushikesh=false;
    }
  }
  
  
 
}
