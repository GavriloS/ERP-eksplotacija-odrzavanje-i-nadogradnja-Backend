import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipTypeDialogComponent } from './membership-type-dialog.component';

describe('MembershipTypeDialogComponent', () => {
  let component: MembershipTypeDialogComponent;
  let fixture: ComponentFixture<MembershipTypeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipTypeDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MembershipTypeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
