import { Component } from '@angular/core';
import Chart from 'chart.js/auto';
import { ProductService } from '../product.service';
@Component({
  selector: 'app-productsell',
  templateUrl: './productsell.component.html',
  styleUrls: ['./productsell.component.css']
})
export class ProductsellComponent {
  year:number=2020;
  product:any;
  public chart: any;
  productName:any[]=[];
  cellQuantity:any[]=[];
  
    constructor(private svc:ProductService){
    this.product=[];
  
    }
      ngOnInit(): void {
        this.svc.getCountByMonth(this.year).subscribe((res)=>{
          this.product=res;
          console.log(res);
          if(this.product!=null){
            for(let i=0;i<this.product.length; i++){
              this.productName.push(this.product[i].title);
              this.cellQuantity.push(this.product[i].quantity);
            }
          }
          this.createChart(this.productName,this.cellQuantity);
        });   
      }
  
      createChart(productName:any,cellQuantity:any){
        this.chart = new Chart("MyChart", {
          type: 'doughnut', //this denotes tha type of chart
          data: {// values on X-Axis
            labels: productName, 
            
             datasets: [
              {
                label: "sell",
                data:cellQuantity , 
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
