import { Component, ComponentRef, EventEmitter, OnInit, Output, ViewChild, ViewContainerRef } from '@angular/core';
import { GroupTrainingType } from '../models/GroupTrainingType.model';
import { GroupTrainingTypeService } from '../services/group-training-type.service';
import { GroupTrainingService } from '../services/group-training.service';
import { CalendarOptions, EventAddArg, FullCalendarComponent } from '@fullcalendar/angular';
import { GroupTraining } from '../models/GroupTraining.model';
import { AuthService } from '../services/auth.service';

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
  groupTrainings:GroupTraining[] = [];
  selectedGroupTraining:GroupTrainingType;
  selectedDate:Date;
  userCapacity:number = 0;
  @ViewChild('calendar') calendarComponent: FullCalendarComponent;

  showParticipateDialog:boolean = false;
  groupTrainingIndex:number;

  // store all created ComponentRefs so that they can be successfully destroyed in eventDestroy
  ngComponentsMap = new Map<HTMLElement, ComponentRef<EventActionsComponent>>();

  // get componentFactory of dynamic component only once
  eventActionsComponentFactory = EventActionsComponent
  showDialog:boolean = false;

  mode:string;


  calendarOptions: CalendarOptions = {

    initialView: 'timeGridWeek',
    allDaySlot:false,
    timeZone:'CET',
    eventClick:this.handleEventClick.bind(this),// bind is important!
    dateClick:this.handleDateClick.bind(this),
    events: [
      { title: 'event 1', date: '2022-06-09T12:30:00',extendedProps:{id:'testId2'} },
      { title: 'event 2', date: '2022-06-08T12:30:00',backgroundColor: 'salmon',extendedProps:{id:'testId'} }

    ],


  };
  constructor(private groupTrainingTypeService:GroupTrainingTypeService,
              private vcRef: ViewContainerRef,
              private groupTrainingService:GroupTrainingService,
              private authService:AuthService) { }

  ngOnInit(): void {
    this.groupTrainingTypeService.getGroupTrainingTypes().subscribe(groupTrainingTypes =>{
      this.groupTrainingTypes.push(...groupTrainingTypes)
    });

    this.groupTrainingService.getGroupTrainings().subscribe(g =>{
      let events = []
      let calendar = this.calendarComponent.getApi();
      this.groupTrainings = g;
      g.forEach(gr =>{
        let event;
        if(gr.actualUserCount === gr.userCapacity){
          event = {title:gr.name,date:gr.dateTimeOfGroupTraining,end: new Date(new Date(gr.dateTimeOfGroupTraining).getTime() + gr.duration*60000),
            backgroundColor:'salmon',extendedProps:{id:gr.groupTrainingId}};

        }else{

          event = {title:gr.name,date:gr.dateTimeOfGroupTraining,end: new Date(new Date(gr.dateTimeOfGroupTraining).getTime() + gr.duration*60000),
            backgroundColor:'green',extendedProps:{id:gr.groupTrainingId}}
      }
      calendar.addEvent(event);
    })
    })
  }
  handleEventClick(arg:any) {

    let inList:Boolean = false;
    for(let i = 0; i< this.groupTrainings.length;i++){
      if(this.groupTrainings[i].groupTrainingId === arg.event.extendedProps['id']){
        for(let j=0; j<this.groupTrainings[i].users.length;j++){
          if(this.groupTrainings[i].users[j] === this.authService.user.value.userId){
              inList = true;
              break;
          }
        }

        if(inList){
          this.mode = 'd'
        }else{
          this.mode ='a'
        }

        this.groupTrainingIndex = i;
        this.showParticipateDialog = true
      }
    }
  }
  handleDateClick(arg:any) {
    if(this.authService.role === 'Trainer'){
      this.selectedDate = arg.date;
      this.showDialog = true;
    }
  }

  closeDialog(){
    this.showDialog = false;
    this.showParticipateDialog = false;
  }

  updateGroupTraining(groupTraining:any){
    console.log("usao")
    console.log(groupTraining);
    for(let i = 0;i<this.groupTrainings.length;i++){
      if(this.groupTrainings[i].groupTrainingId === groupTraining.groupTrainingId){

        this.groupTrainings[i] = groupTraining;
        break;
      }
    }
  }

  submit(){
    if(!!this.selectedDate){
      let calendar = this.calendarComponent.getApi()
      let groupTraining:GroupTraining = {groupTrainingId:null,
                                        groupTrainingTypeId:this.selectedGroupTraining.groupTrainingTypeId,
                                        dateTimeOfGroupTraining:this.selectedDate,
                                        trainerId:this.authService.user.value.userId,
                                        actualUserCount:0,
                                      userCapacity:this.userCapacity,
                                    name:this.selectedGroupTraining.name,
                                  duration:this.selectedGroupTraining.duration,
                                  trainerName:this.authService.user.value.firstName+' '+this.authService.user.value.lastName,
                                users:[]}

      this.groupTrainingService.addGroupTraining(groupTraining).subscribe(g =>{
        let event = {title:this.selectedGroupTraining.name,date:this.selectedDate,end: new Date(this.selectedDate.getTime() + this.selectedGroupTraining.duration * 60000),
          backgroundColor:'green',extendedProps:{id:g.groupTrainingId}}
        calendar.addEvent(event);
        this.closeDialog();
      })


    }





  }







}
