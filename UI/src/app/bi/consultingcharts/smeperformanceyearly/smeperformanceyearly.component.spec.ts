import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SmeperformanceyearlyComponent } from './smeperformanceyearly.component';

describe('SmeperformanceyearlyComponent', () => {
  let component: SmeperformanceyearlyComponent;
  let fixture: ComponentFixture<SmeperformanceyearlyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SmeperformanceyearlyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SmeperformanceyearlyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
