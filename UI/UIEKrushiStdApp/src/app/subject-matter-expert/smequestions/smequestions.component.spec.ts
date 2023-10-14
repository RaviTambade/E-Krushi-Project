import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SmequestionsComponent } from './smequestions.component';

describe('SmequestionsComponent', () => {
  let component: SmequestionsComponent;
  let fixture: ComponentFixture<SmequestionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SmequestionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SmequestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
