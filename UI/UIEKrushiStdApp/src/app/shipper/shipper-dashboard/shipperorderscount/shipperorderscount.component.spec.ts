import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipperorderscountComponent } from './shipperorderscount.component';

describe('ShipperorderscountComponent', () => {
  let component: ShipperorderscountComponent;
  let fixture: ComponentFixture<ShipperorderscountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipperorderscountComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShipperorderscountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
