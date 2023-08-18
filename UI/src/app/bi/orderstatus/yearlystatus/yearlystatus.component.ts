import { Component } from '@angular/core';
import { Chart, Legend } from 'chart.js';
import { BiService } from '../../bi.service';

@Component({
  selector: 'app-yearlystatus',
  templateUrl: './yearlystatus.component.html',
  styleUrls: ['./yearlystatus.component.css']
})
export class YearlystatusComponent {
  order:any;
  public chart: any;
  year:any[]=[];
  totalCount:any[]=[];
  status:any[]=[];
  
  
    constructor(private svc:BiService){
    this.order=[];
  
    }
      ngOnInit(): void {
        this.svc.getYearlySMEPerformance().subscribe((res)=>{
          this.order=res;
          console.log(res)
          if(this.order!=null){
            for(let i=0;i<this.order.length; i++){
              this.year.push(this.order[i].year);
              this.totalCount.push(this.order[i].total);
              this.status.push(this.order[i].status);
            }
          }
          this.createChart(this.year,this.totalCount,this.status);
        });   
      }
  
      createChart(year:any,totalCount:any,status:any){
        this.chart = new Chart("MyChart", {
          type: 'bar', //this denotes tha type of chart
          data: {// values on X-Axis
            labels: year, 
            
             datasets: [
              {
                label: "total",
                data:totalCount, 
                backgroundColor:[ 'red',
                                  'blue',
                                  'green'],
              }  ,
              {
                label: "status",
                data:status , 
                backgroundColor:[ 'red',
                                  'blue',
                                  'green']
              }

            ]
          },
          options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
        });
      }
  }
  


