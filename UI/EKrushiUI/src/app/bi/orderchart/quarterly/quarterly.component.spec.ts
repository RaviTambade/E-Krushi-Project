import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuarterlyComponent } from './quarterly.component';

describe('QuarterlyComponent', () => {
  let component: QuarterlyComponent;
  let fixture: ComponentFixture<QuarterlyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuarterlyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuarterlyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
