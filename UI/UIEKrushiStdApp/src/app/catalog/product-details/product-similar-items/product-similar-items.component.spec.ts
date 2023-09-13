import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductSimilarItemsComponent } from './product-similar-items.component';

describe('ProductSimilarItemsComponent', () => {
  let component: ProductSimilarItemsComponent;
  let fixture: ComponentFixture<ProductSimilarItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductSimilarItemsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductSimilarItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
