import { TestBed } from '@angular/core/testing';

import { ReserveAppointmentStandardService } from './reserve-appointment-standard.service';

describe('ReserveAppointmentStandardService', () => {
  let service: ReserveAppointmentStandardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReserveAppointmentStandardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
