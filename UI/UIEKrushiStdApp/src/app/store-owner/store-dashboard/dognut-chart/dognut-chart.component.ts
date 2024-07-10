import { Component, OnInit } from '@angular/core';
import { BIService } from '@services/bi.service';
import { ChartData, ChartType, ChartEvent } from 'chart.js';
enum TimeIntervalMode {
  today = 'today',
  yesterday = 'yesterday',
  week = 'week',
  month = 'month',
}
@Component({
  selector: 'store-dognut-chart',
  templateUrl: './dognut-chart.component.html',
  styleUrls: ['./dognut-chart.component.css'],
})
export class DognutChartComponent implements OnInit {
  modes = TimeIntervalMode;
  todaysdate: string = new Date().toISOString().slice(0, 10);
  selectedMode: string = this.modes.today;
  storeid: number = 1;

  constructor(private bisvc: BIService) {}
  colorsArray: string[] = [
    'rgb(255, 99, 132)',
    'rgb(54, 162, 235)',
    'rgb(236, 110, 173)',
    'rgb(46, 216, 182)',
    'rgb(255, 205, 86)',
    // 'rgb(255, 83, 112)',
  ];
  public doughnutChartLabels: string[] = [];
  public doughnutChartData: ChartData<'doughnut'> = {
    labels: this.doughnutChartLabels,
    datasets: [
      {
        data: [],
        backgroundColor: [],
      },
    ],
  };
  public doughnutChartType: ChartType = 'doughnut';
  ngOnInit(): void {
    this.fetchCategoryWiseData();
  }
  fetchCategoryWiseData() {
    this.bisvc
      .getCategorywiseProductsCount(
        this.todaysdate,
        this.selectedMode,
        this.storeid
      )
      .subscribe((response) => {
       
        this.doughnutChartData.labels = response.map((r) => r.title);
        this.doughnutChartData.datasets[0].data = response.map(
          (r) => r.quantity
        );
        this.doughnutChartData.datasets[0].backgroundColor =
          this.getRandomColorsFromArray(
            this.colorsArray,
            this.colorsArray.length
          );
      });
  }

  changeMode(mode: string) {
    this.selectedMode = mode;
    this.fetchCategoryWiseData();
  }

  isModeActive(mode: string): boolean {
    return this.selectedMode === mode;
  }

  getRandomColorsFromArray(colorsArray: string[], count: number): string[] {
    const shuffledArray = colorsArray.slice().sort(() => Math.random() - 0.5);

    const randomColors: string[] = [];
    for (let i = 0; i < count; i++) {
      randomColors.push(shuffledArray[i]);
    }
    return randomColors;
  }
}
