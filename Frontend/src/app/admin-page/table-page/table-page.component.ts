import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

import { map } from 'rxjs';
import { BasketService } from 'src/app/services/basket.service';
import { EquipmentTypeService } from 'src/app/services/equipment-type.service';
import { EquipmentService } from 'src/app/services/equipment.service';
import { GroupTrainingTypeService } from 'src/app/services/group-training-type.service';
import { MembershipTypeService } from 'src/app/services/membership-type.service';
import { SuplementTypeService } from 'src/app/services/suplement-type.service';
import { SuplementService } from 'src/app/services/suplement.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-table-page',
  templateUrl: './table-page.component.html',
  styleUrls: ['./table-page.component.scss']
})
export class TablePageComponent implements OnInit, OnChanges {

  @Input() tableName:string;

  tableInput:any;
  headers:any;

  showEquipmentDioalog:boolean = false;
  showSuplementDialog:boolean = false;
  showMembershipTypeDialog:boolean = false;
  showGroupTrainingTypeDialog:boolean = false;
  showEquipmentTypeDialog:boolean = false;
  showSuplementTypeDialog:boolean = false;

  showDeleteDialog:boolean = false;
  element:any;
  mode:string;
  deleteText:string;


  constructor(private equipmentService:EquipmentService,
              private suplementService:SuplementService,
              private basketService:BasketService,
              private membershipTypeService:MembershipTypeService,
              private groupTrainingTypeService:GroupTrainingTypeService,
              private equipentTypeService:EquipmentTypeService,
              private suplementTypeService:SuplementTypeService,
              private userService:UserService) { }


  equipmentTableNames:string[] = ['equipmentId','name','description','manufacturer','quantity','price','equipmentTypeId']
  equipmentTypeTableNames:string[] = ['equipmentTypeId','name']
  suplementTableNames:string[] = ['suplementId','name','description','manufacturer','quantity','price','suplementTypeId']
  suplementTypeTableNames:string[] = ['suplementTypeId','name']
  basketTableNames:string[] = ['basketId','dateTimeOfPurchase','userId']
  membershipTypeTableNames:string[] = ['membershipTypeId','name','numberOfTrainings','numberOfGroupTrainings','price']
  groupTrainingTypeTableNames:string[] = ['groupTrainingTypeId','name','description','duration'];
  userTableNames:string[] = ['userId','firstName','lastName','password','contactNumber','numberOfTrainings','numberOfGroupTraings']



  ngOnInit(): void {
    this.updateTable(this.tableName);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateTable(changes['tableName'].currentValue);
  }

  updateTable(tableName:string){
    switch(tableName){
      case 'Equipment':
        this.equipmentService.getEquipmentsAdmin().subscribe(equipments =>{
          this.tableInput = equipments;
          this.headers = this.equipmentTableNames;

        })
        break;
        case 'Suplement':
          this.suplementService.getEquipmentsAdmin().subscribe(s =>{
            this.tableInput = s;
            this.headers = this.suplementTableNames;
          });
        break;
        case 'Basket':
          this.basketService.getBaskets().pipe(map(b => {

            b.forEach(basket =>{
              basket.userId = basket.user.userId;
            })
            return b
          })).subscribe(b =>{
            this.tableInput = b;
            this.headers = this.basketTableNames;
          });
          break;
        case 'MembershipType':
          this.membershipTypeService.getMembershipTypes().subscribe(mt =>{
            this.tableInput = mt;
            this.headers = this.membershipTypeTableNames;
          })
          break;
        case 'GroupTrainingType':
          this.groupTrainingTypeService.getGroupTrainingTypes().subscribe(gr =>{

            this.tableInput = gr;
            this.headers = this.groupTrainingTypeTableNames;
          });
          break;
        case 'EquipmentType':
          this.equipentTypeService.getEquipmentTypes().subscribe(e =>{
            this.tableInput = e;
            this.headers = this.equipmentTypeTableNames;
          });
          break;
        case 'SuplementType':
          this.suplementTypeService.getSuplementTypes().subscribe(s =>{
            this.tableInput = s;
            this.headers = this.suplementTypeTableNames;
          })
          break;
    }
  }

  deleteRow(element:any){
    this.element = element;

    switch(this.tableName){
      case 'Equipment':
          this.deleteText = element.name;
        break;
      case 'Suplement':
          this.deleteText = element.name;
        break;
      case 'MembershipType':
        this.deleteText = element.name
        break;
      case 'GroupTrainingType':
        this.deleteText = element.name
        break;
      case 'EquipmentType':
        this.deleteText = element.name;
        break;
      case 'SuplementType':
        this.deleteText = element.name
        break;


    }
    this.showDeleteDialog = true;
  }

  modifyRow(element:any){
    this.mode = 'm';
    this.element = element
    switch(this.tableName){
      case 'Equipment':
          this.showEquipmentDioalog = true;
        break;
      case 'Suplement':
          this.showSuplementDialog = true;
        break
      case 'MembershipType':
        this.showMembershipTypeDialog = true;
        break;
      case 'GroupTrainingType':
        this.showGroupTrainingTypeDialog = true;
        break;
      case 'EquipmentType':
        this.showEquipmentTypeDialog = true;
        break;
      case 'SuplementType':
        this.showSuplementTypeDialog = true;
        break;
    }
  }
  addRow(){
    this.mode = 'a';
    this.element = {}
    switch(this.tableName){
      case 'Equipment':
          this.showEquipmentDioalog = true;
        break;
      case 'Suplement':
          this.showSuplementDialog = true;
        break;
        case 'MembershipType':
          this.showMembershipTypeDialog = true;
          break;
        case 'GroupTrainingType':
          this.showGroupTrainingTypeDialog = true;
          break;
        case 'EquipmentType':
          this.showEquipmentTypeDialog = true;
          break;
        case 'SuplementType':
          this.showSuplementTypeDialog = true;
          break;
    }
  }

  closeDialog(){
    this.showDeleteDialog = false;
    this.showEquipmentDioalog = false;
    this.showSuplementDialog = false;
    this.showMembershipTypeDialog = false;
    this.showGroupTrainingTypeDialog = false;
    this.showEquipmentTypeDialog = false;
    this.showSuplementTypeDialog = false;
  }

}
