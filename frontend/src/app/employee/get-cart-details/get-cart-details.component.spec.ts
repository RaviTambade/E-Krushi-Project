import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetCartDetailsComponent } from './get-cart-details.component';

describe('GetCartDetailsComponent', () => {
  let component: GetCartDetailsComponent;
  let fixture: ComponentFixture<GetCartDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetCartDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetCartDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
