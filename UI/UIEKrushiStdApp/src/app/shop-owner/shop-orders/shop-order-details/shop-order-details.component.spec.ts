import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopOrderDetailsComponent } from './shop-order-details.component';

describe('ShopOrderDetailsComponent', () => {
  let component: ShopOrderDetailsComponent;
  let fixture: ComponentFixture<ShopOrderDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShopOrderDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShopOrderDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
