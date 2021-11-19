import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrugstoreOffersComponent } from './drugstore-offers.component';

describe('DrugstoreOffersComponent', () => {
  let component: DrugstoreOffersComponent;
  let fixture: ComponentFixture<DrugstoreOffersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrugstoreOffersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DrugstoreOffersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
