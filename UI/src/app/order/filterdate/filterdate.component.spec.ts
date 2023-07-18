import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterdateComponent } from './filterdate.component';

describe('FilterdateComponent', () => {
  let component: FilterdateComponent;
  let fixture: ComponentFixture<FilterdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilterdateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FilterdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
