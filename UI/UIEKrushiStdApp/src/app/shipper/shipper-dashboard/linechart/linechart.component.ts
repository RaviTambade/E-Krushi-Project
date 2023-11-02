import { Component, OnInit, ViewChild } from '@angular/core';
import { Chart, ChartConfiguration, ChartType } from 'chart.js';
import Annotation from 'chartjs-plugin-annotation';
import { BaseChartDirective } from 'ng2-charts';
import { BIService } from 'src/app/Services/bi.service';

@Component({
  selector: 'app-linechart',
  templateUrl: './linechart.component.html',
  styleUrls: ['./linechart.component.css']
})
export class LinechartComponent implements OnInit{
  public lineChartLegend = true;

  public lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: [],
        // stepped:true,
        label: 'Order Count',
        backgroundColor: 'lightblue',
        borderColor: 'blue',
        pointBackgroundColor: 'blue',
        pointBorderColor: 'blue',
        pointRadius: 5,
        pointBorderWidth: 2,
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin',
      },
    ],
    labels: [],
  };

  public lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      line: {
        tension: 0.7,
      },
    },
    scales: {
      // We use this empty structure as a placeholder for dynamic theming.
      y: {
        position: 'left',

        grid: {
          color: 'rgba(255,0,0,0.3)',
        },
        ticks: {
          color: 'red',
        },
      },
    },

    plugins: {
      legend: { display: true },
      annotation: {
        annotations: [
          {
            type: 'line',
            scaleID: 'x',
            borderColor: 'black',
            borderWidth: 2,
            label: {
              position: 'center',
              color: 'black',
              content: 'LineAnno',
              font: {
                weight: 'bold',
              },
            },
          },
        ],
      },
    },
  };
  public lineChartType: ChartType = 'bar';

  @ViewChild(BaseChartDirective) chart?: BaseChartDirective;

  constructor(private service: BIService) {
    Chart.register(Annotation);
  }
  year: number = new Date().getFullYear();
  shipperId: number=4;

  ngOnInit(): void {
    
    
    this.service
      .getDeliveredOrders(this.year, this.shipperId)
      .subscribe((response) => {
       
        this.lineChartData.labels = response.map((item) => item.month );
        this.lineChartData.datasets[0].data = response.map(
          (item) => item.ordersCount 
        );
      });
  }
}
