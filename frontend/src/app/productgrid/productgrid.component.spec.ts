import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductgridComponent } from './productgrid.component';

describe('ProductgridComponent', () => {
  let component: ProductgridComponent;
  let fixture: ComponentFixture<ProductgridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductgridComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
