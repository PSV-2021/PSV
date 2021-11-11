import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseDrugsComponent } from './purchase-drugs.component';

describe('PurchaseDrugsComponent', () => {
  let component: PurchaseDrugsComponent;
  let fixture: ComponentFixture<PurchaseDrugsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseDrugsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseDrugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
