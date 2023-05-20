import { Component , OnInit } from '@angular/core';

@Component({
  selector: 'app-customerlist',
  templateUrl: './customerlist.component.html',
  styleUrls: ['./customerlist.component.css']
})
export class CustomerlistComponent implements OnInit{
  

customers = [
  {id:1,firstName:'kavya', lastName: 'bangar'},
  {id:2,firstName:'vidya', lastName: 'bangar'},
  {id:3,firstName:'aarohi',lastName: 'bangar'},
  {id:4,firstName:'kiran', lastName: 'bangar'},
];

ngOnInit(){

}


}
