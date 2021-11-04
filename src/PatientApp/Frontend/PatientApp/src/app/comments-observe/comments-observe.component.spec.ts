import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CommentsObserveComponent } from './comments-observe.component';

describe('CommentsObserveComponent', () => {
  let component: CommentsObserveComponent;
  let fixture: ComponentFixture<CommentsObserveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommentsObserveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommentsObserveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
