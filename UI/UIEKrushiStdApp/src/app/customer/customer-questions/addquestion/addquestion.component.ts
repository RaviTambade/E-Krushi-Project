import { Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { InsertQuestion } from 'src/app/Models/InsertQuestion';
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
  customerId:number|undefined;
constructor(private svc : ConsultingService){
  this.customerId=Number(localStorage.getItem(LocalStorageKeys.userId))
  console.log(this.customerId)
}
categories:Questioncategory[]=[]
selectedcategory:string='';
CategoryId!: number;

question:InsertQuestion={

  description: '',
  categoryId: 0,
  customerId: 0,
 
}
  ngOnInit(): void {
    this.svc.getAllCategories().subscribe((response)=>{
this.categories=response;

    })
  }

  insertQuestion(form:any){
     
    console.log(this.question.categoryId);
    console.log(this.customerId);
    console.log(form)
    this.svc.insertQuestion(form).subscribe((res)=>{
      this.question=res;
      console.log(form)
    })
  }


 

}
