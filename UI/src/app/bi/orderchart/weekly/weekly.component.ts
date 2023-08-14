import { Component } from '@angular/core';
import { Chart } from 'chart.js';
import { BiService } from '../../bi.service';


@Component({
  selector: 'app-weekly',
  templateUrl: './weekly.component.html',
  styleUrls: ['./weekly.component.css']
})
export class WeeklyComponent {
  year:number=2020;
    orders:any;
    public chart: any;
    weekNumber:any[]=[];
    totalCount:any[]=[];
    
      constructor(private svc:BiService){
      this.orders=[];
      }

        ngOnInit(): void {
          this.svc.getMonthlyOrders(this.year).subscribe((res)=>{
            this.orders=res;
            if(this.orders!=null){
              for(let i=0;i<this.orders.length; i++){
                this.weekNumber.push(this.orders[i].weekNumber);
                this.totalCount.push(this.orders[i].total);
              }
            }
            this.createChart(this.weekNumber,this.totalCount);
          });   
        }
    
        createChart(weekNumber:any,totalCount:any){
          this.chart = new Chart("MyChart", {
            type: 'bar', //this denotes tha type of chart
            data: {// values on X-Axis
              labels: weekNumber, 
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
