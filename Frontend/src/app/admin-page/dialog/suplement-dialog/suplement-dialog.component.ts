import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Suplement } from 'src/app/models/Suplement.model';
import { SuplementType } from 'src/app/models/SuplementType.model';
import { SuplementTypeService } from 'src/app/services/suplement-type.service';
import { SuplementService } from 'src/app/services/suplement.service';

@Component({
  selector: 'app-suplement-dialog',
  templateUrl: './suplement-dialog.component.html',
  styleUrls: ['./suplement-dialog.component.scss']
})
export class SuplementDialogComponent implements OnInit {

  constructor(private suplementService:SuplementService,
              private suplementTypeService:SuplementTypeService) { }

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() suplement:Suplement;
  @Input() mode:string;

  selectedType:SuplementType;

  suplementTypes:SuplementType[] = [];

  ngOnInit(): void {
    this.suplementTypeService.getSuplementTypes().subscribe(st =>{
      this.suplementTypes.push(...st);
      if(this.mode === 'm'){
        st.forEach(s =>{
          if(s.suplementTypeId === this.suplement.suplementTypeId){
            this.selectedType= s;
          }
        })
    }
    })
  }



  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){
    this.suplement.suplementTypeId = this.selectedType.suplementTypeId;
    if(this.mode === 'm'){
      this.suplementService.modifySuplement(this.suplement).subscribe(s =>{
        this.closeDialog();
      })
    }else if(this.mode === 'a'){
      this.suplementService.addEquipment(this.suplement).subscribe(s =>{
        this.closeDialog();
      });
    }
  }

}
