import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sortedlist',
  templateUrl: './sortedlist.component.html',
  styleUrls: ['./sortedlist.component.css']
})
export class SortedlistComponent implements OnInit{
numbers:any[] |undefined;  

constructor(){}

  ngOnInit(): void {
    this.numbers=[3,1,4,8,5,7,6];
  }

 onChange(){
  this.numbers?.sort((a,b)=>a-b)
 }

}
