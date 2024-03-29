import { Component, OnInit } from '@angular/core';
import { Category } from '@models/category';
import { CatalogService } from '@services/catalog.service';
;

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent implements OnInit {
  categories: Category[] = [];

  constructor(private catlogsvc: CatalogService) { }

  ngOnInit(): void {
    this.catlogsvc.getCategories().subscribe((res) => {
      this.categories = res;
    });
  }
}
