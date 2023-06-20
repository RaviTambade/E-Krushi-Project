import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderpaymentComponent } from './orderpayment.component';

describe('OrderpaymentComponent', () => {
  let component: OrderpaymentComponent;
  let fixture: ComponentFixture<OrderpaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderpaymentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderpaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
