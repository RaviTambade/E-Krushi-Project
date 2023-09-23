import { TestBed } from '@angular/core/testing';

import { ConsultingService } from './consulting.service';

describe('ConsultingService', () => {
  let service: ConsultingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConsultingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
