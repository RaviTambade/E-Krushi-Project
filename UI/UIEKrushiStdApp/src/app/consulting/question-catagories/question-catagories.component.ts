import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Questioncategory } from 'src/app/Models/Questioncategory';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-question-catagories',
  templateUrl: './question-catagories.component.html',
  styleUrls: ['./question-catagories.component.css']
})
export class QuestionCatagoriesComponent implements OnInit {

  categories:Questioncategory[]=[]
  category:Questioncategory ={
    id: 0,
    category: ''
  }
constructor(private svc:ConsultingService,private router: Router){}
  ngOnInit(): void {
   this.svc.getAllCategories().subscribe((response)=>{
    this.categories=response; 
    console.log(response);
   })
  }

  onClickCategory(id:number){
    this.router.navigate(['consulting/categorywisequestions',id]);
  }
}
