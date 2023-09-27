import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionCatagoriesComponent } from './question-catagories.component';

describe('QuestionCatagoriesComponent', () => {
  let component: QuestionCatagoriesComponent;
  let fixture: ComponentFixture<QuestionCatagoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestionCatagoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuestionCatagoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
