import { TestBed } from '@angular/core/testing';

import { StoreownerService } from './storeowner.service';

describe('StoreownerService', () => {
  let service: StoreownerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoreownerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
