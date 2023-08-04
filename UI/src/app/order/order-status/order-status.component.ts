import { Component } from '@angular/core';
import Chart from 'chart.js/auto';
import { OrderhubService } from '../orderhub.service';

@Component({
  selector: 'app-order-status',
  templateUrl: './order-status.component.html',
  styleUrls: ['./order-status.component.css']
})
export class OrderStatusComponent {
  year:number=2020;
  product:any;
  public chart: any;
  status:any[]=[];
  total:any[]=[];
  
    constructor(private svc:OrderhubService){
    this.product=[];
  
    }
      ngOnInit(): void {
        this.svc.orderStatus(this.year).subscribe((res)=>{
          this.product=res;
          console.log(res);
          if(this.product!=null){
            for(let i=0;i<this.product.length; i++){
              this.status.push(this.product[i].status);
              this.total.push(this.product[i].total);
            }
          }
          this.createChart(this.status,this.total);
        });   
      }
  
      createChart(status:any,total:any){
        this.chart = new Chart("MyChart", {
          type: 'doughnut', //this denotes tha type of chart
          data: {// values on X-Axis
            labels: status, 
            
             datasets: [
              {
                label: "sell",
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
