import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sortedlist',
  templateUrl: './sortedlist.component.html',
  styleUrls: ['./sortedlist.component.css']
})
export class SortedlistComponent implements OnInit{
// numbers:any[] |undefined;  
expenseEntries:any[] |undefined;

constructor(){
     // this.numbers=[3,1,4,8,5,7,6];
    this.expenseEntries=[
      {"item":"Pizza", "amount":10, "category":"Food", "location":"KFC", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":15, "category":"Food", "location":"Mcdonald", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":23, "category":"Food", "location":"KFC", "spenton":"12/8/2023"},
      {"item":"Pizza", "amount":27, "category":"Food", "location":"Mcdonald", "spenton":"12/1/2023"},
      {"item":"Pizza", "amount":12, "category":"Food", "location":"KFC", "spenton":"12/3/2023"},
      {"item":"Pizza", "amount":11, "category":"Food", "location":"Mcdonald", "spenton":"12/6/2023"},
      {"item":"Pizza", "amount":18, "category":"Food", "location":"v", "spenton":"12/2/2023"}
    ];

}

  ngOnInit(): void {
    
  }

 onChange(){
  // this.numbers?.sort((a,b)=>a-b)
   this.expenseEntries?.sort((a,b)=>a.amount-b.amount)
 }
}
