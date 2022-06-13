import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupTrainingTableComponent } from './group-training-table.component';

describe('GroupTrainingTableComponent', () => {
  let component: GroupTrainingTableComponent;
  let fixture: ComponentFixture<GroupTrainingTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupTrainingTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupTrainingTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
