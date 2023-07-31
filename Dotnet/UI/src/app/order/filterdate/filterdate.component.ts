import { Component } from '@angular/core';
import { OrderhubService } from '../orderhub.service';

@Component({
  selector: 'app-filterdate',
  templateUrl: './filterdate.component.html',
  styleUrls: ['./filterdate.component.css']
})
export class FilterdateComponent {

  orders:any[];
  fromDate:string;
  toDate:string;

  constructor(private svc: OrderhubService){
    this.orders=[];
    this.fromDate='';
    this.toDate='';

  }
  
  onSubmit() {
    this.svc.filterDate(this.fromDate, this.toDate).subscribe((response) => {
        this.orders = response;
        console.log(this.orders);
      });
    };
  }

