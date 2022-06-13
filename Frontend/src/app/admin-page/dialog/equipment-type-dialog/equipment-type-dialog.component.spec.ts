import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentTypeDialogComponent } from './equipment-type-dialog.component';

describe('EquipmentTypeDialogComponent', () => {
  let component: EquipmentTypeDialogComponent;
  let fixture: ComponentFixture<EquipmentTypeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EquipmentTypeDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EquipmentTypeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
