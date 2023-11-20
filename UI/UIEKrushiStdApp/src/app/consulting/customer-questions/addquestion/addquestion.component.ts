import { Component, OnInit } from '@angular/core';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { TokenClaims } from '@enums/tokenclaims';
import { InsertQuestion } from '@models/InsertQuestion';
import { Questioncategory } from '@models/Questioncategory';
import { AuthenticationService } from '@services/authentication.service';
import { ConsultingService } from '@services/consulting.service';

@Component({
  selector: 'app-addquestion',
  templateUrl: './addquestion.component.html',
  styleUrls: ['./addquestion.component.css'],
})
export class AddquestionComponent implements OnInit {
  customerId: number = 0;
  constructor(
    private svc: ConsultingService,
    private authsvc: AuthenticationService
  ) {
    this.customerId = Number(
      this.authsvc.getClaimFromToken(TokenClaims.userId)
    );
  }
  categories: Questioncategory[] = [];

  question: InsertQuestion = {
    description: '',
    categoryId: 0,
    customerId: 0,
  };
  ngOnInit(): void {
    this.svc.getAllCategories().subscribe((response) => {
      this.categories = response;
    });
  }

  insertQuestion(form: InsertQuestion) {
    form.customerId = this.customerId;
    this.svc.insertQuestion(form).subscribe((res) => {
      if (res) {
        alert('question added');
      }
    });
  }
}
