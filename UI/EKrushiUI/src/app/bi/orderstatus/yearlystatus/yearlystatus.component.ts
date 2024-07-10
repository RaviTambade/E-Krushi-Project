import { Component } from '@angular/core';
import { Chart, Legend } from 'chart.js';
import { BiService } from '../../bi.service';
import { RequestReport } from '../OrderStatus';

@Component({
  selector: 'app-yearlystatus',
  templateUrl: './yearlystatus.component.html',
  styleUrls: ['./yearlystatus.component.css']
})
export class YearlystatusComponent {
  // order:any;
  // public chart: any;
  // year:any[]=[];
  // totalCount:any[]=[];
  // status:any[]=[];
  
 
  selectedYearValue: string='';
  public currentDate=new Date();
  public chart: any;
  years: number[] = [];
  status:string[] = ["initiated", "delivered", "inprogress","cancelled","approved"]
  total: any[] = [];
  report: RequestReport[] = [];
  currentYear:string='';
  constructor(private svc:BiService) {
    // this.order=[];
    const currentYear = new Date().getFullYear();
    for (let year = currentYear ; year >= currentYear - 10; year--) {
      this.years.push(year);
    }
    this.currentYear = new Date().getFullYear().toString();
  }
  
    // constructor(private svc:BiService){
    // this.order=[];
  
    ngOnInit(): void {
      this.svc.orderStatus(this.currentYear).subscribe((res) => {
        console.log(res);
        this.report = res;
        if (this.report != null) {
          for (const month of this.status) {
            console.log("for")
            const matchingData = this.report.find((item) => month.includes(item.total));
            if (matchingData) {
              this.total.push(matchingData.status);
              console.log(this.total);
            } else {
              this.total.push(0); // If data not available for the day, use 0
            }
          }
          this.createChart();
        }
      })
  
  
    }
  
    createChart() {
      this.chart = new Chart("MyChart", {
  
        type: 'bar', //this denotes tha type of chart
        data: {// values on X-Axis
          labels: this.status,
  
          datasets: [
            {
              label: "order status",
              data: this.total,
              backgroundColor: 'orange'
            }
          ]
        },
        options: {
          scales: {
            x: {},
            y: {
              min: 0,
              max: 50,
              ticks: {
                stepSize: 5,
              },
            },
          },
        }
  
      });
    }
      onYearChange() {
        this.chart.destroy();
        this.report=[];
        this.total=[];
        console.log('Selected week:', this.selectedYearValue);
    
        this.svc.orderStatus(this.selectedYearValue).subscribe((res) => {
          console.log(res);
          this.report = res;
          console.log(this.report);
          if (this.report != null) {
            for (const orderStatus of this.status) {
              //err
              const matchingData = this.report.find((item) => orderStatus.includes(item.total));
              console.log(matchingData);
              if (matchingData) {
                this.total.push(matchingData.status);
                console.log(this.total);
              } else {
                this.total.push(0); // If data not available for the day, use 0
              }
            }
            this.createChart();
          }
        })
        }
    }

