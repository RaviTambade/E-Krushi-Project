import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-questions',
  templateUrl: './customer-questions.component.html',
  styleUrls: ['./customer-questions.component.css']
})
export class CustomerQuestionsComponent {
  constructor(private router:Router){}
  Status:boolean=false;


  OnClick(){
    this.router.navigate(['customer/addquestion']);
  }
}
