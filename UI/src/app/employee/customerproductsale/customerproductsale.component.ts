import { Component } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-customerproductsale',
  templateUrl: './customerproductsale.component.html',
  styleUrls: ['./customerproductsale.component.css']
})
export class CustomerproductsaleComponent {

custId:number=1;
products:any;
public chart: any;
title:any[]=[];
totalQuantity:any[]=[];

  constructor(private svc:EmployeeService){
  this.products=[];

  }
    ngOnInit(): void {
      this.svc.getCustomerReport(this.custId).subscribe((res)=>{
        this.products=res;
        console.log(res);
        if(this.products!=null){
          for(let i=0;i<this.products.length; i++){
            this.title.push(this.products[i].title);
            this.totalQuantity.push(this.products[i].totalQuantity);
          }
        }
        this.createChart(this.title,this.totalQuantity);
      });   
    }

    createChart(title:any,totalQuantity:any){
      this.chart = new Chart("MyChart", {
        type: 'bar', //this denotes tha type of chart
        data: {// values on X-Axis
          labels: title, 
           datasets: [
            {
              label: "Products",
              data:totalQuantity , 
              backgroundColor: 'orange'
            }  ,
            {
              label: "Products",
              data:totalQuantity , 
              backgroundColor: 'orange'
            }  
          ]
        },
        options: {
          aspectRatio:5
        }
      });
    }
}
