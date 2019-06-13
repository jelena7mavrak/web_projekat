import { TestBed } from '@angular/core/testing';

import { ScheduleService } from 'src/app/service/schedule.service';

describe('ScheduleService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ScheduleService = TestBed.get(ScheduleService);
    expect(service).toBeTruthy();
  });
});
