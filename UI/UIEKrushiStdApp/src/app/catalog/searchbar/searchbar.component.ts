import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CatalogService } from 'src/app/Services/catalog.service';

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css'],
})
export class SearchbarComponent {
  searchString: string = '';
  suggestions: string[] = [];
  constructor(private router: Router, private catalogsvc: CatalogService) {}
  onSearch() {
    this.suggestions = [];
    this.router.navigate(['catalog/products', this.searchString]);
  }

  getSuggestions() {
    this.catalogsvc
      .getProductNameSuggestions(this.searchString)
      .subscribe((res) => {
        this.suggestions = res;
      });
  }

  onSelectSuggestion(suggestion: string) {
    this.searchString = suggestion;
    this.onSearch();
  }
}
