import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenderFinishingComponent } from './tender-finishing.component';

describe('TenderFinishingComponent', () => {
  let component: TenderFinishingComponent;
  let fixture: ComponentFixture<TenderFinishingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenderFinishingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenderFinishingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
