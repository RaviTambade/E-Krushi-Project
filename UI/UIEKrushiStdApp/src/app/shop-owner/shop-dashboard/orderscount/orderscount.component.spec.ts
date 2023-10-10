import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderscountComponent } from './orderscount.component';

describe('OrderscountComponent', () => {
  let component: OrderscountComponent;
  let fixture: ComponentFixture<OrderscountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderscountComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderscountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
