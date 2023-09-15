import { Component } from '@angular/core';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {
  categories:any =[{
    imageUrl:"/assets/Agri Equipments.jpeg" ,title: "Agri implements"
  },
  {
    imageUrl:"/assets/fertilizer.jpeg" ,title : "Fertilizer"
  },{
    imageUrl:"/assets/pestisides.jpeg" ,title : "Pestisides"
  },
  
  {
    imageUrl:"/assets/seed.jpeg" ,title : "Seeds"
  },  
  {
    imageUrl:"/assets/cattle feed.jpeg", title : "Cattle Feed"
  },  
  {
    imageUrl:"/assets/organic.jpeg" , title : "Organic Product"
  },  
  {
    imageUrl:"/assets/kisan mitra.jpeg" ,title : "Kisan Mitra"
  }, 
]


}
