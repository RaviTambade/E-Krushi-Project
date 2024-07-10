import { Component } from '@angular/core';
import { BiService } from '../../bi.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-monthlystatus',
  templateUrl: './monthlystatus.component.html',
  styleUrls: ['./monthlystatus.component.css']
})
export class MonthlystatusComponent {

  year:number=2020;
  orders:any;
  public chart: any;
  status:any[]=[];
  total:any[]=[];
  
    constructor(private svc:BiService){
    this.orders=[];
  
    }
      ngOnInit(): void {
        this.svc.orderStatus(this.year).subscribe((res)=>{
          this.orders=res;
          console.log(res);
          if(this.orders!=null){
            for(let i=0;i<this.orders.length; i++){
              this.status.push(this.orders[i].status);
              this.total.push(this.orders[i].total);
            }
          }
          this.createChart(this.status,this.total);
        });   
      }
  
      createChart(status:any,total:any){
        this.chart = new Chart("MyChart", {
          type: 'pie', //this denotes tha type of chart
          data: {// values on X-Axis
            labels: status, 
            
             datasets: [
              {
                label: "orderStatus",
                data:total , 
                backgroundColor: ['orange','blue','green','red','pink']
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


