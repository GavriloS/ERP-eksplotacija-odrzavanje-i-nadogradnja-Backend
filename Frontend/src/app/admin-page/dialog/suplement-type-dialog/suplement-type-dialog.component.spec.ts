import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuplementTypeDialogComponent } from './suplement-type-dialog.component';

describe('SuplementTypeDialogComponent', () => {
  let component: SuplementTypeDialogComponent;
  let fixture: ComponentFixture<SuplementTypeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuplementTypeDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuplementTypeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
