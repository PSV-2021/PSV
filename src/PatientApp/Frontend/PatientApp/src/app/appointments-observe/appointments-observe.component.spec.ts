import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentsObserveComponent } from './appointments-observe.component';

describe('AppointmentsObserveComponent', () => {
  let component: AppointmentsObserveComponent;
  let fixture: ComponentFixture<AppointmentsObserveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppointmentsObserveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentsObserveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
