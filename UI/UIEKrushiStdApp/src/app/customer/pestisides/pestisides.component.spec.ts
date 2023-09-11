import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PestisidesComponent } from './pestisides.component';

describe('PestisidesComponent', () => {
  let component: PestisidesComponent;
  let fixture: ComponentFixture<PestisidesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PestisidesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PestisidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
