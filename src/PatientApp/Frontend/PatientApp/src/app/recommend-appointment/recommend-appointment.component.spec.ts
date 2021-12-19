import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendAppointmentComponent } from './recommend-appointment.component';

describe('RecommendAppointmentComponent', () => {
  let component: RecommendAppointmentComponent;
  let fixture: ComponentFixture<RecommendAppointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecommendAppointmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
