import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlystatusComponent } from './monthlystatus.component';

describe('MonthlystatusComponent', () => {
  let component: MonthlystatusComponent;
  let fixture: ComponentFixture<MonthlystatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonthlystatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonthlystatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
