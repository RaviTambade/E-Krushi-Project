import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { BiService } from '../../bi.service';


@Component({
  selector: 'app-yearly',
  templateUrl: './yearly.component.html',
  styleUrls: ['./yearly.component.css']
})
export class YearlyComponent implements OnInit {

    year:number=2020;
    orders:any;
    public chart: any;
    month:any[]=[];
    totalCount:any[]=[];
    
      constructor(private svc:BiService){
      this.orders=[];
    
      }
        ngOnInit(): void {
          this.svc.getCountByMonth(this.year).subscribe((res)=>{
            this.orders=res;
            if(this.orders!=null){
              for(let i=0;i<this.orders.length; i++){
                this.month.push(this.orders[i].monthName);
                this.totalCount.push(this.orders[i].count);
              }
            }
            this.createChart(this.month,this.totalCount);
          });   
        }
    
        createChart(month:any,totalCount:any){
          this.chart = new Chart("MyChart", {
            type: 'bar', //this denotes tha type of chart
            data: {// values on X-Axis
              labels: month, 
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
    

