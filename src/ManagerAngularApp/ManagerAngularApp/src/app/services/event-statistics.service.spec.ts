import { TestBed } from '@angular/core/testing';

import { EventStatisticsService } from './event-statistics.service';

describe('EventStatisticsService', () => {
  let service: EventStatisticsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventStatisticsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
