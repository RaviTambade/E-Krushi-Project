import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsellComponent } from './productsell.component';

describe('ProductsellComponent', () => {
  let component: ProductsellComponent;
  let fixture: ComponentFixture<ProductsellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsellComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductsellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
