import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrugstoreOfferComponent } from './drugstore-offer.component';

describe('DrugstoreOfferComponent', () => {
  let component: DrugstoreOfferComponent;
  let fixture: ComponentFixture<DrugstoreOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrugstoreOfferComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DrugstoreOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
