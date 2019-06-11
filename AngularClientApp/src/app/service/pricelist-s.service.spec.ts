import { TestBed } from '@angular/core/testing';

import { PricelistSService } from './pricelist-s.service';

describe('PricelistSService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PricelistSService = TestBed.get(PricelistSService);
    expect(service).toBeTruthy();
  });
});
