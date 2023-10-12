import { Component, OnInit, ViewChild } from '@angular/core';
import { Chart, ChartConfiguration, ChartType } from 'chart.js';
import { BIService } from 'src/app/Services/bi.service';
import Annotation from 'chartjs-plugin-annotation';
import { BaseChartDirective } from 'ng2-charts';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';

@Component({
  selector: 'shop-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css'],
})
export class LineChartComponent implements OnInit {

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
  public lineChartType: ChartType = 'line';

  @ViewChild(BaseChartDirective) chart?: BaseChartDirective;

  constructor(private service: BIService) {
    Chart.register(Annotation);
  }
  year: number = new Date().getFullYear();
  storeId: number | undefined;

  ngOnInit(): void {
    const storeId = Number(localStorage.getItem(LocalStorageKeys.storeId));
    if (Number.isNaN(storeId) || storeId == 0) {
      return;
    }
    this.storeId = storeId;
    this.service
      .getMonthsWithOrders(this.year, this.storeId)
      .subscribe((response) => {
        console.log(response);
        this.lineChartData.labels = response.map((item) => item.month);
        this.lineChartData.datasets[0].data = response.map(
          (item) => item.orderCount
        );
      });
  }
}
