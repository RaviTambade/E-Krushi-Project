import { TestBed } from '@angular/core/testing';

import { ProductHubServiceService } from './product-hub-service.service';

describe('ProductHubServiceService', () => {
  let service: ProductHubServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductHubServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
