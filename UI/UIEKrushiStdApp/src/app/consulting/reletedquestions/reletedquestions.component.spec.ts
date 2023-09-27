import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReletedquestionsComponent } from './reletedquestions.component';

describe('ReletedquestionsComponent', () => {
  let component: ReletedquestionsComponent;
  let fixture: ComponentFixture<ReletedquestionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReletedquestionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReletedquestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
