import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchProductResultComponent } from './search-product-result.component';

describe('SearchProductResultComponent', () => {
  let component: SearchProductResultComponent;
  let fixture: ComponentFixture<SearchProductResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchProductResultComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchProductResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
