import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccessMembershipComponent } from './success-membership.component';

describe('SuccessMembershipComponent', () => {
  let component: SuccessMembershipComponent;
  let fixture: ComponentFixture<SuccessMembershipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuccessMembershipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuccessMembershipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
