import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { BiService } from '../../bi.service';

@Component({
  selector: 'app-totalrevenue',
  templateUrl: './totalrevenue.component.html',
  styleUrls: ['./totalrevenue.component.css']
})
export class TotalrevenueComponent implements OnInit{

  year:number=2020;
    list:any;
    public chart: any;
    month:any[]=[];
    totalRevenue:any[]=[];
    
      constructor(private svc:BiService){
      this.list=[];
    
      }
        ngOnInit(): void {
          this.svc.getTotalRevenue(this.year).subscribe((res)=>{
            this.list=res;
            if(this.list!=null){
              for(let i=0;i<this.list.length; i++){
                this.month.push(this.list[i].monthName);
                this.totalRevenue.push(this.list[i].total);
              }
            }
            this.createChart(this.month,this.totalRevenue);
          });   
        }
    
        createChart(month:any,totalRevenue:any){
          this.chart = new Chart("MyChart", {
            type: 'bar', //this denotes tha type of chart
            data: {// values on X-Axis
              labels: month, 
               datasets: [
                {
                  label: "Orders",
                  data:totalRevenue , 
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

