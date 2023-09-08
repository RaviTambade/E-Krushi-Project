import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipperDashboardComponent } from './shipper-dashboard.component';

describe('ShipperDashboardComponent', () => {
  let component: ShipperDashboardComponent;
  let fixture: ComponentFixture<ShipperDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipperDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShipperDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
