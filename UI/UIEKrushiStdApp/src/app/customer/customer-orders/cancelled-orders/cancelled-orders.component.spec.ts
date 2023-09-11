import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancelledOrdersComponent } from './cancelled-orders.component';

describe('CancelledOrdersComponent', () => {
  let component: CancelledOrdersComponent;
  let fixture: ComponentFixture<CancelledOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CancelledOrdersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CancelledOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
