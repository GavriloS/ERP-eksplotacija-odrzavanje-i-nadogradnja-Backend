import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuplementDialogComponent } from './suplement-dialog.component';

describe('SuplementDialogComponent', () => {
  let component: SuplementDialogComponent;
  let fixture: ComponentFixture<SuplementDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuplementDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuplementDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
