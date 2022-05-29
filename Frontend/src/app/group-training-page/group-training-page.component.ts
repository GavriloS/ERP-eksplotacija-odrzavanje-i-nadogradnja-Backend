import { Component, ComponentRef, EventEmitter, OnInit, Output, ViewContainerRef } from '@angular/core';
import { GroupTrainingType } from '../models/GroupTrainingType.model';
import { GroupTrainingTypeService } from '../services/group-training-type.service';
import { GroupTrainingService } from '../services/group-training.service';
import { CalendarOptions } from '@fullcalendar/angular';

@Component({
  template: `<p-button (onClick)="deleted.emit(info.event)" icon="pi pi-trash"></p-button>`,
})
export class EventActionsComponent {
  info: any;
  @Output() deleted = new EventEmitter();
}


@Component({
  selector: 'app-group-training-page',
  templateUrl: './group-training-page.component.html',
  styleUrls: ['./group-training-page.component.scss']
})
export class GroupTrainingPageComponent implements OnInit {

  groupTrainingTypes:GroupTrainingType[] = [];


  // store all created ComponentRefs so that they can be successfully destroyed in eventDestroy
  ngComponentsMap = new Map<HTMLElement, ComponentRef<EventActionsComponent>>();

  // get componentFactory of dynamic component only once
  eventActionsComponentFactory = EventActionsComponent


  calendarOptions: CalendarOptions = {

    initialView: 'timeGridWeek',
    allDaySlot:false,
    timeZone:'CET',
    dateClick: this.handleDateClick.bind(this), // bind is important!
    events: [
      { title: 'event 1', date: '2022-05-26T12:30:00' },
      { title: 'event 2', date: '2022-05-28T12:30:00' }

    ],


  };
  constructor(private groupTrainingTypeService:GroupTrainingTypeService,
    private vcRef: ViewContainerRef) { }

  ngOnInit(): void {
    this.groupTrainingTypeService.getGroupTrainingTypes().subscribe(groupTrainingTypes =>{
      this.groupTrainingTypes.push(...groupTrainingTypes)
    });
  }

  handleDateClick(arg:any) {
    alert("CLICKKK")
    alert('date click! ' + arg.dateStr)
  }

}
