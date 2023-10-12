import { Component, OnInit } from '@angular/core';
import { ChartType } from 'chart.js';
import { BIService } from 'src/app/Services/bi.service';

@Component({
  selector: 'shop-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit{
  

  public lineChartOptions: any = {
    responsive: true
  };
  public lineChartLabels: string[] = [];
  public lineChartType :ChartType= 'line';
  public lineChartLegend = true;
  public lineChartData: any[] = [];

  constructor(private service:BIService){

  }
  year:number=2023;
  storeid:number=1;
  
  ngOnInit(): void {
    
    this.service.getMonthsWithOrders(this.year,this.storeid).subscribe((response)=>{

        console.log(response);
         this.lineChartLabels=response.map(r=>r.month);
         this.lineChartData=response.map(r=>r.orders);
    })
  }
  
}
