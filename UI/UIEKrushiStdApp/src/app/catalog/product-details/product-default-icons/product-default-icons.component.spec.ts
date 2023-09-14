import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDefaultIconsComponent } from './product-default-icons.component';

describe('ProductDefaultIconsComponent', () => {
  let component: ProductDefaultIconsComponent;
  let fixture: ComponentFixture<ProductDefaultIconsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDefaultIconsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductDefaultIconsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
