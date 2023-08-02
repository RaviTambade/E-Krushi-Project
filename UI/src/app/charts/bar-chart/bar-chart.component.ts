import { Component,OnInit} from '@angular/core';
import Chart from 'chart.js/auto';
import { ChartsService } from '../charts.service';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})

export class BarChartComponent implements OnInit{

year:number=2020;
orders:any;
public chart: any;
month:any[]=[];
totalCount:any[]=[];

  constructor(private svc:ChartsService){
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
