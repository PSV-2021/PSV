import { TestBed } from '@angular/core/testing';

import { AppointmentObserveService } from './appointment-observe.service';

describe('AppointmentObserveService', () => {
  let service: AppointmentObserveService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppointmentObserveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
