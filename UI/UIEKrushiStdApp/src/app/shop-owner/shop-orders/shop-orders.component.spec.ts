import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopOrdersComponent } from './shop-orders.component';

describe('ShopOrdersComponent', () => {
  let component: ShopOrdersComponent;
  let fixture: ComponentFixture<ShopOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopOrdersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShopOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
