import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlypaymentComponent } from './monthlypayment.component';

describe('MonthlypaymentComponent', () => {
  let component: MonthlypaymentComponent;
  let fixture: ComponentFixture<MonthlypaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonthlypaymentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonthlypaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
