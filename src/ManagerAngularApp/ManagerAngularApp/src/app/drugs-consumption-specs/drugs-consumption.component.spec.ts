import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DrugsConsumptionComponent } from './drugs-consumption.component';

describe('DrugsConsumptionComponent', () => {
  let component: DrugsConsumptionComponent;
  let fixture: ComponentFixture<DrugsConsumptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrugsConsumptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DrugsConsumptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
