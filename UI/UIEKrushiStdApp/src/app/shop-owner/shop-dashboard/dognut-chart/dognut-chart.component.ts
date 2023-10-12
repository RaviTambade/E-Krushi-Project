import { Component } from '@angular/core';
import { ChartData, ChartType, ChartEvent } from 'chart.js';

@Component({
  selector: 'shop-dognut-chart',
  templateUrl: './dognut-chart.component.html',
  styleUrls: ['./dognut-chart.component.css']
})
export class DognutChartComponent {
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
  
   
    this.doughnutChartData.labels=['a','b','c','d']
    this.doughnutChartData.datasets[0].data=[20,40,30,40]

}
}
