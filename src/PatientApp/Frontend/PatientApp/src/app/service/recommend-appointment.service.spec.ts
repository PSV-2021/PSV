import { TestBed } from '@angular/core/testing';

import { RecommendAppointmentService } from './recommend-appointment.service';

describe('RecommendAppointmentService', () => {
  let service: RecommendAppointmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RecommendAppointmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
