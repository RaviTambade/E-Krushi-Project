import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipperOrdersComponent } from './shipper-orders.component';

describe('ShipperOrdersComponent', () => {
  let component: ShipperOrdersComponent;
  let fixture: ComponentFixture<ShipperOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipperOrdersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShipperOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
