import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EquipmentType } from 'src/app/models/EquipmentType.model';
import { EquipmentTypeService } from 'src/app/services/equipment-type.service';

@Component({
  selector: 'app-equipment-type-dialog',
  templateUrl: './equipment-type-dialog.component.html',
  styleUrls: ['./equipment-type-dialog.component.scss']
})
export class EquipmentTypeDialogComponent implements OnInit {


  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() equipmentType:EquipmentType;
  @Input() mode:string;

  constructor(private equipmentTypeService:EquipmentTypeService) { }

  ngOnInit(): void {
  }

  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){

    if(this.mode === 'm'){
      this.equipmentTypeService.modifyEquipmentType(this.equipmentType).subscribe(e =>{

        this.closeDialog();
      })
    }else if(this.mode === 'a'){
      this.equipmentTypeService.addEquipmentType(this.equipmentType).subscribe(e =>{
        this.closeDialog();
      });
    }
  }

}
