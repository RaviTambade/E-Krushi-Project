import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { BiService } from '../../bi.service';

@Component({
  selector: 'app-yearly',
  templateUrl: './yearly.component.html',
  styleUrls: ['./yearly.component.css']
})

export class YearlyComponent implements OnInit{
 
    orders:any;
    public chart: any;
    year:any[]=[];
    totalCount:any[]=[];
    
      constructor(private svc:BiService){
      this.orders=[];
    
      }
        ngOnInit(): void {
          this.svc.getYearlyOrders().subscribe((res)=>{
            this.orders=res;
            if(this.orders!=null){
              for(let i=0;i<this.orders.length; i++){
                this.year.push(this.orders[i].year);
                this.totalCount.push(this.orders[i].total);
              }
            }
            this.createChart(this.year,this.totalCount);
          });   
        }
    
        createChart(year:any,totalCount:any){
          this.chart = new Chart("MyChart", {
            type: 'bar', //this denotes tha type of chart
            data: {// values on X-Axis
              labels: year, 
               datasets: [
                {
                  label: "Orders",
                  data:totalCount , 
                  backgroundColor: 'orange'
                }  
              ]
            },
            options: {
              aspectRatio:2.5
            }
          });
        }
    }
   
    
    
    

