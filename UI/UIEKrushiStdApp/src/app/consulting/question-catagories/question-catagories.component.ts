import { Component, OnInit } from '@angular/core';
import { Questioncategory } from 'src/app/Models/Questioncategory';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-question-catagories',
  templateUrl: './question-catagories.component.html',
  styleUrls: ['./question-catagories.component.css']
})
export class QuestionCatagoriesComponent implements OnInit {

  categories:Questioncategory[]=[]
constructor(private svc:ConsultingService){}
  ngOnInit(): void {
   this.svc.getAllCategories().subscribe((response)=>{
    this.categories=response;
   })
  }


}
