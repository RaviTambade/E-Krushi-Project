import { Component, OnInit } from '@angular/core';
import { ChartData, ChartType, ChartEvent } from 'chart.js';
import { BIService } from 'src/app/Services/bi.service';

@Component({
  selector: 'shop-dognut-chart',
  templateUrl: './dognut-chart.component.html',
  styleUrls: ['./dognut-chart.component.css']
})
export class DognutChartComponent implements OnInit {
  constructor(private service:BIService){}
  todaysdate:string=new Date().toISOString().slice(0,10);
  mode:string='month';
  storeid:number=1;
  public doughnutChartLabels: string[] = [];
  public doughnutChartData: ChartData<'doughnut'> = {
    labels: this.doughnutChartLabels,
    datasets: [
      { data: [] ,
        backgroundColor: [
          'rgb(255, 99, 132)',
          'rgb(54, 162, 235)',
          'rgb(255, 205, 86)'
        ],},
    ],
  };
  public doughnutChartType: ChartType = 'doughnut';
ngOnInit(): void {
  
   this.service.getCategorywiseProductsCount(this.todaysdate,this.mode,this.storeid).subscribe((response)=>{
     console.log(response);
      

     this.doughnutChartData.labels=response.map(r=>r.title);

    this.doughnutChartData.datasets[0].data=response.map(r=>r.quantity);

     
   })
    
}
}
