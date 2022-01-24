import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HospitalChartsComponent } from './hospital-charts.component';

describe('HospitalChartsComponent', () => {
  let component: HospitalChartsComponent;
  let fixture: ComponentFixture<HospitalChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HospitalChartsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HospitalChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
