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

        fill: 'origin',
        backgroundColor:"rgb(252, 103, 250)",
        borderColor: 'purple',
        pointBackgroundColor: 'rgb(252, 80, 83)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgb(252, 80, 83) ',
      },
    ],
    labels: [],
    
  };

  public lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      line: {
        tension: 0.8,
      },
  
    },

    scales: {
      x: {
        grid: {
          display: false,
          // color:'white',
        },
        ticks: {
          color: 'black',
        },
      },
      y: {
        position: 'left',
        grid: {
          display: false,
          // color:'white',
        },
        ticks: {
          color: 'black',
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
              color: 'white',
              content: 'LineAnno',
              font: {
                // weight: 'bold',
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
       
        this.lineChartData.labels = response.map((item) => item.month.slice(0,3));
        this.lineChartData.datasets[0].data = response.map(
          (item) => item.orderCount 
        );
      });
  }
}
