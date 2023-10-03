import { TestBed } from '@angular/core/testing';

import { EvsService } from './evs.service';

describe('EvsService', () => {
  let service: EvsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EvsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
