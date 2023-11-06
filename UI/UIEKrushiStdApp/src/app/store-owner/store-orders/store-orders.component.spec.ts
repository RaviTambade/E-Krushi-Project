import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreOrdersComponent } from './store-orders.component';

describe('ShopOrdersComponent', () => {
  let component: StoreOrdersComponent;
  let fixture: ComponentFixture<StoreOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoreOrdersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
