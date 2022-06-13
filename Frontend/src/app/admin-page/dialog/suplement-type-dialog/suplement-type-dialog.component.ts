import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SuplementType } from 'src/app/models/SuplementType.model';
import { SuplementTypeService } from 'src/app/services/suplement-type.service';

@Component({
  selector: 'app-suplement-type-dialog',
  templateUrl: './suplement-type-dialog.component.html',
  styleUrls: ['./suplement-type-dialog.component.scss']
})
export class SuplementTypeDialogComponent implements OnInit {

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() suplementType:SuplementType;
  @Input() mode:string;

  constructor(private suplementTypeService:SuplementTypeService) { }

  ngOnInit(): void {
  }

  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){

    if(this.mode === 'm'){
      this.suplementTypeService.modifySuplementType(this.suplementType).subscribe(s =>{

        this.closeDialog();
      })
    }else if(this.mode === 'a'){
      this.suplementTypeService.addSuplementType(this.suplementType).subscribe(s =>{
        this.closeDialog();
      });
    }
  }
}
