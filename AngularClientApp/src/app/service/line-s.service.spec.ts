import { TestBed } from '@angular/core/testing';

import { LineSService } from 'src/app/service/line-s.service';

describe('LineSService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LineSService = TestBed.get(LineSService);
    expect(service).toBeTruthy();
  });
});
