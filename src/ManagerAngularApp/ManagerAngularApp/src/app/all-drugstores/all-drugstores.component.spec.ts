import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllDrugstoresComponent } from './all-drugstores.component';

describe('AllDrugstoresComponent', () => {
  let component: AllDrugstoresComponent;
  let fixture: ComponentFixture<AllDrugstoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllDrugstoresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllDrugstoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
