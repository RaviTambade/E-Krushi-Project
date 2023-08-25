import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangecontactnumberComponent } from './changecontactnumber.component';

describe('ChangecontactnumberComponent', () => {
  let component: ChangecontactnumberComponent;
  let fixture: ComponentFixture<ChangecontactnumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangecontactnumberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangecontactnumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
