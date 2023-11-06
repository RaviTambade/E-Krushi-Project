import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DognutChartComponent } from './dognut-chart.component';

describe('DognutChartComponent', () => {
  let component: DognutChartComponent;
  let fixture: ComponentFixture<DognutChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DognutChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DognutChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
