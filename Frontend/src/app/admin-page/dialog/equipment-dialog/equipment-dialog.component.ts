import { Component, Input, OnInit, Output,EventEmitter } from '@angular/core';
import { Equipment } from 'src/app/models/Equipment.model';
import { EquipmentType } from 'src/app/models/EquipmentType.model';
import { EquipmentTypeService } from 'src/app/services/equipment-type.service';
import { EquipmentService } from 'src/app/services/equipment.service';


@Component({
  selector: 'app-equipment-dialog',
  templateUrl: './equipment-dialog.component.html',
  styleUrls: ['./equipment-dialog.component.scss']
})
export class EquipmentDialogComponent implements OnInit {

  constructor(private equipmentService:EquipmentService,
              private equipmentTypeService:EquipmentTypeService) { }

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() equipment:Equipment;
  @Input() mode:string;

  selectedType:EquipmentType;

  equipmentTypes:EquipmentType[] = [];
  ngOnInit(): void {
    this.equipmentTypeService.getEquipmentTypes().subscribe(et =>{
      this.equipmentTypes.push(...et);
      if(this.mode === 'm'){
        et.forEach(e =>{
          if(e.equipmentTypeId === this.equipment.equipmentTypeId){
            this.selectedType= e;
          }
        })
    }
    })
  }

  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){
    this.equipment.equipmentTypeId = this.selectedType.equipmentTypeId;
    if(this.mode === 'm'){
      this.equipmentService.modifyEquipment(this.equipment).subscribe(e =>{
        console.log(e);
        this.closeDialog();
      })
    }else if(this.mode === 'a'){
      this.equipmentService.addEquipment(this.equipment).subscribe(e =>{
        this.closeDialog();
      });
    }
  }

}
