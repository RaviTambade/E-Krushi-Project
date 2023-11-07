import { Component, OnInit } from '@angular/core';
import { Question } from '@models/question';
import { ConsultingService } from '@services/consulting.service';
import { UserService } from '@services/user.service';


@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css'],
})
export class QuestionsComponent implements OnInit {
  constructor(
    private svc: ConsultingService,
    private usersvc: UserService
  ) {}
  questions: Question[] = [];
  ngOnInit(): void {
    this.svc.getQuestions().subscribe((res) => {
      this.questions = res;
      console.log("🚀 ~ this.svc.getQuestions ~ questions:", res);

      let customerIds = this.questions.map((u) => u.customerId);
      let customerIdString = customerIds.join(',');
      this.usersvc
        .getUserNamesWithId(customerIdString)
        .subscribe((userNames) => {
          this.questions.forEach((question) => {
            let matchingName = userNames.find(
              (element) => element.id == question.customerId
            );

            if (matchingName != undefined) {
              question.customerName = matchingName.fullName;
            }
          });
        });
    });
  }
}
