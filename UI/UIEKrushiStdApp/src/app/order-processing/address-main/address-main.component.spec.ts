import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressMainComponent } from './address-main.component';

describe('AddressMainComponent', () => {
  let component: AddressMainComponent;
  let fixture: ComponentFixture<AddressMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressMainComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddressMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
