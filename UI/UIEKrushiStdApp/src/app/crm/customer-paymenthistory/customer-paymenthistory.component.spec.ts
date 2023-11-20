import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerPaymenthistoryComponent } from './customer-paymenthistory.component';

describe('CustomerPaymenthistoryComponent', () => {
  let component: CustomerPaymenthistoryComponent;
  let fixture: ComponentFixture<CustomerPaymenthistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerPaymenthistoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerPaymenthistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
