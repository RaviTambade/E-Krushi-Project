import { TestBed } from '@angular/core/testing';

import { AgridoctorService } from './agridoctor.service';

describe('AgridoctorService', () => {
  let service: AgridoctorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AgridoctorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
