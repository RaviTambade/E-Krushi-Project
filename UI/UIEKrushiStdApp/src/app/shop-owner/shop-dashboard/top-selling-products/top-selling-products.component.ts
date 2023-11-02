import { Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { TopProduct } from 'src/app/Models/top-product';
import { BIService } from 'src/app/Services/bi.service';

@Component({
  selector: 'shop-top-selling-products',
  templateUrl: './top-selling-products.component.html',
  styleUrls: ['./top-selling-products.component.css'],
})
export class TopSellingProductsComponent implements OnInit {
  products: TopProduct[] = [];
  storeId:number|undefined;
  currentDate: string = new Date().toISOString().slice(0, 10);
  modes:string[]=['today','yesterday','week','month'];
  selectedMode: string = this.modes[0];

  constructor(private bisvc: BIService) {}
  ngOnInit(): void {
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));

    if (Number.isNaN(storeId) || storeId == 0) {
      return;
    }
    this.storeId=storeId;

    this.fetchData();
  }

  fetchData() {
    if(this.storeId==undefined){
      return;
    }
    
    this.bisvc
      .getTopFiveSellingProducts(this.currentDate, this.selectedMode, this.storeId)
      .subscribe((res) => {
        this.products = res;
       
      });
  }
}
