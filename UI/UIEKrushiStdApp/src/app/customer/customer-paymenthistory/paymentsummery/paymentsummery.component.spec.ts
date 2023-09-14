import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentsummeryComponent } from './paymentsummery.component';

describe('PaymentsummeryComponent', () => {
  let component: PaymentsummeryComponent;
  let fixture: ComponentFixture<PaymentsummeryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentsummeryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaymentsummeryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
