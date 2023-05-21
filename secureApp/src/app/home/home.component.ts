import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {




  name:string='akash';
  //console.log(name);

onclick(){
console.log(this.name)
}
}
