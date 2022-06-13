import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { EquipmentTypeService } from 'src/app/services/equipment-type.service';
import { EquipmentService } from 'src/app/services/equipment.service';
import { GroupTrainingTypeService } from 'src/app/services/group-training-type.service';
import { MembershipTypeService } from 'src/app/services/membership-type.service';
import { SuplementTypeService } from 'src/app/services/suplement-type.service';
import { SuplementService } from 'src/app/services/suplement.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.scss']
})
export class DeleteDialogComponent implements OnInit {

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() type:string;
  @Input() text:string;
  @Input() entity:any;
  constructor(private equipmentService:EquipmentService,
              private suplementService:SuplementService,
              private basketService:BasketService,
              private membershipTypeService:MembershipTypeService,
              private groupTrainingTypeService:GroupTrainingTypeService,
              private equipentTypeService:EquipmentTypeService,
              private suplementTypeService:SuplementTypeService,
              private userService:UserService) { }

  ngOnInit(): void {
  }

  delete(){
    switch(this.type){
      case 'Equipment':
        this.equipmentService.deleteEquipment(this.entity.equipmentId).subscribe(e =>{
          this.closeDialog();
        });
        break;
        case 'Suplement':
          this.suplementService.deleteSuplement(this.entity.suplementId).subscribe(s =>{
            this.closeDialog();
          });
        break;

        case 'MembershipType':
          this.membershipTypeService.deleteMembershipType(this.entity.membershipTypeId).subscribe(mt =>{
            this.closeDialog();
          })
          break;
        case 'GroupTrainingType':
          this.groupTrainingTypeService.deleteGroupTrainingType(this.entity.groupTrainingType).subscribe(gr =>{
            this.closeDialog();

          });
          break;
        case 'EquipmentType':
          this.equipentTypeService.deleteEquipmentType(this.entity.equipmentTypeId).subscribe(e =>{
            this.closeDialog();
          });
          break;
        case 'SuplementType':
          this.suplementTypeService.deleteSuplementType(this.entity.suplementTypeId).subscribe(s =>{
            this.closeDialog();
          })
          break;
    }
  }

  closeDialog(){
    this.deleteItself.emit();
  }

}
