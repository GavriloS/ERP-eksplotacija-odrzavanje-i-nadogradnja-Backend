import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableWithoutButtonsComponent } from './table-without-buttons.component';

describe('TableWithoutButtonsComponent', () => {
  let component: TableWithoutButtonsComponent;
  let fixture: ComponentFixture<TableWithoutButtonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableWithoutButtonsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableWithoutButtonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
