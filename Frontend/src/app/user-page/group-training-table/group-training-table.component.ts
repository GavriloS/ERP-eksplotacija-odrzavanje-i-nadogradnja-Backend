import { Component, OnInit } from '@angular/core';
import { ConfirmationService, ConfirmEventType, MessageService } from 'primeng/api';
import { GroupTraining } from 'src/app/models/GroupTraining.model';
import { AuthService } from 'src/app/services/auth.service';
import { GroupTrainingService } from 'src/app/services/group-training.service';

@Component({
  selector: 'app-group-training-table',
  templateUrl: './group-training-table.component.html',
  styleUrls: ['./group-training-table.component.scss']
})
export class GroupTrainingTableComponent implements OnInit {

  groupTrainings:GroupTraining[] = [];
  constructor(private groupTrainingService:GroupTrainingService,
              private authService:AuthService,
              private confirmationService: ConfirmationService) { }

  headers:string[] = ['Naziv','Datum','Broj prijavljenih korisnika'];
  ngOnInit(): void {
    this.groupTrainingService.getGroupTrainingByTrainer(this.authService.user.value.userId).subscribe(g => {
      this.groupTrainings = g;
    });
  }


  deleteGroupTraining(id:string){

    this.groupTrainingService.deleteGroupTraining(id).subscribe(g =>{
      for(let i = 0;i<this.groupTrainings.length;i++){
        if(this.groupTrainings[i].groupTrainingId === id){
          this.groupTrainings.splice(i,1);
          break;
        }
      }
    });
  }



  confirmDialog(groupTraining:GroupTraining) {
    console.log("eo")
    this.confirmationService.confirm({
        message: `Da li ste sigurni da želite da obrišete grupni trening ${groupTraining.name}?`,
        header: 'Upozorenje',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
           this.deleteGroupTraining(groupTraining.groupTrainingId)
        },
        reject: (type: any) => {
        }
    });
}


}
