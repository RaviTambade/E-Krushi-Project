import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCategoriesDetailsComponent } from './product-categories-details.component';

describe('ProductCategoriesDetailsComponent', () => {
  let component: ProductCategoriesDetailsComponent;
  let fixture: ComponentFixture<ProductCategoriesDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductCategoriesDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductCategoriesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
