import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderProcessingMainComponent } from './order-processing-main.component';

describe('OrderProcessingMainComponent', () => {
  let component: OrderProcessingMainComponent;
  let fixture: ComponentFixture<OrderProcessingMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderProcessingMainComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderProcessingMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
