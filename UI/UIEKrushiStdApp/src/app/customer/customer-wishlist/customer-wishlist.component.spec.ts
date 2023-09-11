import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerWishlistComponent } from './customer-wishlist.component';

describe('CustomerWishlistComponent', () => {
  let component: CustomerWishlistComponent;
  let fixture: ComponentFixture<CustomerWishlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerWishlistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerWishlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
