import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit{
  myList: any[] = ['item1', 'item2', 'item3','item4', 'item5', 'item6','item7', 'item8', 'item9',];
  currentIndex = 0;

  
  
  ngOnInit(): void {
  
  }

  nextItem() {
    if (this.currentIndex< this.myList.length - 1) {
      this.currentIndex++;
    }
  }
  
  previousItem() {
    if (this.currentIndex > 1) {
      this.currentIndex--;
    }
  }
  
 

  
  
  


}
