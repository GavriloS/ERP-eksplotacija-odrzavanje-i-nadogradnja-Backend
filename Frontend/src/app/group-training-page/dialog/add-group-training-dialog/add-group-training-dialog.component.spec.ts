import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGroupTrainingDialogComponent } from './add-group-training-dialog.component';

describe('AddGroupTrainingDialogComponent', () => {
  let component: AddGroupTrainingDialogComponent;
  let fixture: ComponentFixture<AddGroupTrainingDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGroupTrainingDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGroupTrainingDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
