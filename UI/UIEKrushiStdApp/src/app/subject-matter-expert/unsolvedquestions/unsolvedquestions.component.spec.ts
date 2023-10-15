import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnsolvedquestionsComponent } from './unsolvedquestions.component';

describe('UnsolvedquestionsComponent', () => {
  let component: UnsolvedquestionsComponent;
  let fixture: ComponentFixture<UnsolvedquestionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnsolvedquestionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnsolvedquestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
