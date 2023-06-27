import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestioncategoryComponent } from './questioncategory.component';

describe('QuestioncategoryComponent', () => {
  let component: QuestioncategoryComponent;
  let fixture: ComponentFixture<QuestioncategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestioncategoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuestioncategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
