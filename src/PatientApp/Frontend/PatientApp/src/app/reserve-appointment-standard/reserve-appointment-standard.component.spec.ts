import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReserveAppointmentStandardComponent } from './reserve-appointment-standard.component';

describe('ReserveAppointmentStandardComponent', () => {
  let component: ReserveAppointmentStandardComponent;
  let fixture: ComponentFixture<ReserveAppointmentStandardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReserveAppointmentStandardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReserveAppointmentStandardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
