import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalInfoRegistrationComponent } from './personal-info-registration.component';

describe('PersonalInfoRegistrationComponent', () => {
  let component: PersonalInfoRegistrationComponent;
  let fixture: ComponentFixture<PersonalInfoRegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonalInfoRegistrationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonalInfoRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
