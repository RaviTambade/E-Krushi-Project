import { TestBed } from '@angular/core/testing';

import { BIService } from './bi.service';

describe('BIService', () => {
  let service: BIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
