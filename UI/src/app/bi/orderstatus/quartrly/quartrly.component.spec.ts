import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuartrlyComponent } from './quartrly.component';

describe('QuartrlyComponent', () => {
  let component: QuartrlyComponent;
  let fixture: ComponentFixture<QuartrlyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuartrlyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuartrlyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
