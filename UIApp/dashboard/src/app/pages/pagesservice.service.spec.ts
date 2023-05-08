import { TestBed } from '@angular/core/testing';

import { PagesserviceService } from './pagesservice.service';

describe('PagesserviceService', () => {
  let service: PagesserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PagesserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
