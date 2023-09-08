import { Component } from '@angular/core';
import { ContactNumber } from '../contactnumber';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-changecontactnumber',
  templateUrl: './changecontactnumber.component.html',
  styleUrls: ['./changecontactnumber.component.css']
})
export class ChangecontactnumberComponent {

userId:any;
contactnumber:ContactNumber={
    newcontactnumber: '',
    password:''
  };

  constructor(private svc :UsersService){
    this.userId=localStorage.getItem("userId");
  }
   

  changeContactNumber(form:ContactNumber){
    this.svc.changeContactNumber(this.contactnumber).subscribe((res)=>{
      if (res) {
        alert("Contact Number changed")
      }
    })
  }

 
}
