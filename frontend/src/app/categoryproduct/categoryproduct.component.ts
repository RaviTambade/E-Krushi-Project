import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProducthubService } from '../producthub.service';
import { Category } from '../category';

@Component({
  selector: 'app-categoryproduct',
  templateUrl: './categoryproduct.component.html',
  styleUrls: ['./categoryproduct.component.css']
})
export class CategoryproductComponent implements OnInit{

  form: FormGroup;
  // matcher = new MyErrorStateMatcher();

  categories: Category[] | undefined;

  category = new FormControl(null, [Validators.required]);

  constructor(private service: ProducthubService) {
    //fetch all available countries from service
    this.form = new FormGroup({
      category: this.category
    });
  }

  ngOnInit(): void {
    this.service.getCategories().subscribe((response)=>{
      this.categories = response;
      console.log(this.categories);
    });
  }
}


