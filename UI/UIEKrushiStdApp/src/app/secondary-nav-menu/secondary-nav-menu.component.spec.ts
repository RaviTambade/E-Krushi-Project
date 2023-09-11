import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecondaryNavMenuComponent } from './secondary-nav-menu.component';

describe('SecondaryNavMenuComponent', () => {
  let component: SecondaryNavMenuComponent;
  let fixture: ComponentFixture<SecondaryNavMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SecondaryNavMenuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SecondaryNavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
