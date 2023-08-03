import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SMEPerformanceComponent } from './smeperformance.component';

describe('SMEPerformanceComponent', () => {
  let component: SMEPerformanceComponent;
  let fixture: ComponentFixture<SMEPerformanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SMEPerformanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SMEPerformanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
