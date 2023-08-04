import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerproductsaleComponent } from './customerproductsale.component';

describe('CustomerproductsaleComponent', () => {
  let component: CustomerproductsaleComponent;
  let fixture: ComponentFixture<CustomerproductsaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerproductsaleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerproductsaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
