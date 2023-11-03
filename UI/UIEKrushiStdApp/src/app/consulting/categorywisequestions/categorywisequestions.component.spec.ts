import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategorywisequestionsComponent } from '../../catalog/search-product-result/categorywisequestions.component';

describe('CategorywisequestionsComponent', () => {
  let component: CategorywisequestionsComponent;
  let fixture: ComponentFixture<CategorywisequestionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategorywisequestionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategorywisequestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
