import { Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { InsertQuestion } from '@models/InsertQuestion';
import { Questioncategory } from '@models/Questioncategory';
import { ConsultingService } from '@services/consulting.service';


@Component({
  selector: 'app-addquestion',
  templateUrl: './addquestion.component.html',
  styleUrls: ['./addquestion.component.css'],
})
export class AddquestionComponent implements OnInit {
  customerId: number | undefined;
  constructor(private svc: ConsultingService) {
    this.customerId = Number(localStorage.getItem(LocalStorageKeys.userId));
  }
  categories: Questioncategory[] = [];

  question: InsertQuestion = {
    description: '',
    categoryId: 0,
    customerId: Number(localStorage.getItem(LocalStorageKeys.userId)),
  };
  ngOnInit(): void {
    this.svc.getAllCategories().subscribe((response) => {
      this.categories = response;
    });
  }

  insertQuestion(form: InsertQuestion) {
    this.svc.insertQuestion(form).subscribe((res) => {
      if(res){
alert("question added")
      }
    });
  }
}
