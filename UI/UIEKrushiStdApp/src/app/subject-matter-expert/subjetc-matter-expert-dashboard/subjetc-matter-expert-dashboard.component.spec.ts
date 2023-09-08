import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjetcMatterExpertDashboardComponent } from './subjetc-matter-expert-dashboard.component';

describe('SubjetcMatterExpertDashboardComponent', () => {
  let component: SubjetcMatterExpertDashboardComponent;
  let fixture: ComponentFixture<SubjetcMatterExpertDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubjetcMatterExpertDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubjetcMatterExpertDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
