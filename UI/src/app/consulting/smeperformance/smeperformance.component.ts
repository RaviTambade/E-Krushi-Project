import { Component } from '@angular/core';
import Chart from 'chart.js/auto';
import { ConsultingService } from '../consulting.service';

@Component({
  selector: 'app-smeperformance',
  templateUrl: './smeperformance.component.html',
  styleUrls: ['./smeperformance.component.css']
})
export class SMEPerformanceComponent {
  year:number=2023;
  sme:any;
  public chart: any;
  name:any[]=[];
  totalCount:any[]=[];
  
    constructor(private svc:ConsultingService){
    this.sme=[];
  
    }
      ngOnInit(): void {
        this.svc.getCountByMonth(this.year).subscribe((res)=>{
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
                backgroundColor: 'blue'
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
