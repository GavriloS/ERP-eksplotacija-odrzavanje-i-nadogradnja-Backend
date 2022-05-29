import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupTrainingCardComponent } from './group-training-card.component';

describe('GroupTrainingCardComponent', () => {
  let component: GroupTrainingCardComponent;
  let fixture: ComponentFixture<GroupTrainingCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupTrainingCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupTrainingCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
