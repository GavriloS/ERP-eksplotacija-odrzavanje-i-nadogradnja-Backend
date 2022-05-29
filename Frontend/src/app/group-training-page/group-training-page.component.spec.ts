import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupTrainingPageComponent } from './group-training-page.component';

describe('GroupTrainingPageComponent', () => {
  let component: GroupTrainingPageComponent;
  let fixture: ComponentFixture<GroupTrainingPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupTrainingPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupTrainingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
