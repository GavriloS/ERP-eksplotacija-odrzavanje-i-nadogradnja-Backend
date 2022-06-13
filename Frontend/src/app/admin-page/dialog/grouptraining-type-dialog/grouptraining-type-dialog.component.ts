import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { GroupTrainingType } from 'src/app/models/GroupTrainingType.model';
import { GroupTrainingTypeService } from 'src/app/services/group-training-type.service';


@Component({
  selector: 'app-grouptraining-type-dialog',
  templateUrl: './grouptraining-type-dialog.component.html',
  styleUrls: ['./grouptraining-type-dialog.component.scss']
})
export class GrouptrainingTypeDialogComponent implements OnInit {



  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() groupTrainingType:GroupTrainingType;
  @Input() mode:string;

  constructor(private groupTrainingTypeService:GroupTrainingTypeService) { }

  ngOnInit(): void {
  }


  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){

    if(this.mode === 'm'){
      this.groupTrainingTypeService.modifyGroupTrainingType(this.groupTrainingType).subscribe(g =>{

        this.closeDialog();
      })
    }else if(this.mode === 'a'){
      this.groupTrainingTypeService.addGroupTrainingType(this.groupTrainingType).subscribe(g =>{
        this.closeDialog();
      });
    }
  }

}
