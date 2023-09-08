import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalrevenueComponent } from './totalrevenue.component';

describe('TotalrevenueComponent', () => {
  let component: TotalrevenueComponent;
  let fixture: ComponentFixture<TotalrevenueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TotalrevenueComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TotalrevenueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
