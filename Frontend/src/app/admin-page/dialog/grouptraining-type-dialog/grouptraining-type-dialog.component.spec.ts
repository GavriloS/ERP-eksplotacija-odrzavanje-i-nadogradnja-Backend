import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrouptrainingTypeDialogComponent } from './grouptraining-type-dialog.component';

describe('GrouptrainingTypeDialogComponent', () => {
  let component: GrouptrainingTypeDialogComponent;
  let fixture: ComponentFixture<GrouptrainingTypeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GrouptrainingTypeDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GrouptrainingTypeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
