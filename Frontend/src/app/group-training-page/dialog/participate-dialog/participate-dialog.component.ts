import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { GroupTraining } from 'src/app/models/GroupTraining.model';
import { AuthService } from 'src/app/services/auth.service';
import { GroupTrainingService } from 'src/app/services/group-training.service';

@Component({
  selector: 'app-participate-dialog',
  templateUrl: './participate-dialog.component.html',
  styleUrls: ['./participate-dialog.component.scss']
})
export class ParticipateDialogComponent implements OnInit {

  constructor(private groupTrainingService:GroupTrainingService,
              private authService:AuthService) { }

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() groupTraining:GroupTraining;
  @Output() groupTrainingChange = new EventEmitter();
  @Input() mode:string;
  @Output() updateGroupTrainingEvent = new EventEmitter<GroupTraining>();

  text:string;





  ngOnInit(): void {
    if(this.mode === 'a'){
      this.text = 'Da li želite da rezervišete mesto za grupni trening?';
    }else if(this.mode === 'd'){
      this.text = 'Da li želite da uklonite rezervaciju?'
    }

  }

  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){
    if(this.mode === 'a'){
      this.groupTrainingService.addUserToGroupTraining(this.groupTraining.groupTrainingId,this.authService.user.value.userId).subscribe(g =>{
        this.updateGroupTrainingEvent.emit(g);
        this.closeDialog();
      });
    }else if(this.mode === 'd'){
      this.groupTrainingService.deleteUserFromGroupTraining(this.groupTraining.groupTrainingId,this.authService.user.value.userId).subscribe(g =>{
        this.updateGroupTrainingEvent.emit(g);
        this.closeDialog();
      })
    }
  }

}
