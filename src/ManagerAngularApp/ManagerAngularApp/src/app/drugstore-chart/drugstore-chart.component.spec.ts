import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrugstoreChartComponent } from './drugstore-chart.component';

describe('DrugstoreChartComponent', () => {
  let component: DrugstoreChartComponent;
  let fixture: ComponentFixture<DrugstoreChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrugstoreChartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DrugstoreChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
