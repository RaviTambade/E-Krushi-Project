import { Component } from '@angular/core';
import { BiService } from '../../bi.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-smeperformanceyearly',
  templateUrl: './smeperformanceyearly.component.html',
  styleUrls: ['./smeperformanceyearly.component.css']
})
export class SmeperformanceyearlyComponent {

  year:number=2023;
  sme:any;
  public chart: any;
  name:any[]=[];
  totalCount:any[]=[];
  
    constructor(private svc:BiService){
    this.sme=[];
  
    }
      ngOnInit(): void {
        this.svc.SmePerformanceByMonth(this.year).subscribe((res)=>{
          this.sme=res;
          if(this.sme!=null){
            for(let i=0;i<this.sme.length; i++){
              this.name.push(this.sme[i].name);
              this.totalCount.push(this.sme[i].count);
            }
          }
          this.createChart(this.name,this.totalCount);
        });   
      }
  
      createChart(name:any,totalCount:any){
        this.chart = new Chart("MyChart", {
          type: 'doughnut', //this denotes tha type of chart
          data: {// values on X-Axis
            labels: name, 
            
             datasets: [
              {
                label: "Answers",
                data:totalCount , 
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
  