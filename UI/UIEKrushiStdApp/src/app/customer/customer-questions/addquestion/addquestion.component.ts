import { Component, OnInit } from '@angular/core';
import { Questioncategory } from 'src/app/Models/Questioncategory';
import { Category } from 'src/app/Models/category';
import { Question } from 'src/app/Models/question';
import { ConsultingService } from 'src/app/Services/consulting.service';

@Component({
  selector: 'app-addquestion',
  templateUrl: './addquestion.component.html',
  styleUrls: ['./addquestion.component.css']
})
export class AddquestionComponent  implements OnInit {
constructor(private svc : ConsultingService){}
categories:Questioncategory[]=[]
selectedcategory:string='';
question:Question={
  id: 0,
  description: '',
  categoryId: 0,
  date: '',
  customerId: 0,
  name: ''
}
  ngOnInit(): void {
    this.svc.getAllCategories().subscribe((response)=>{
this.categories=response;
    })
  }

  insertQuestion(form:any){
    this.svc.insertQuestion(form).subscribe((res)=>{
      this.question=res;
    })
  }


}
