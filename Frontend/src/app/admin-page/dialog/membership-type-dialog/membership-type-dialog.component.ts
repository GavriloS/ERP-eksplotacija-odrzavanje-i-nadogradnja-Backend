import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MembershipType } from 'src/app/models/membershipType.model';
import { MembershipTypeService } from 'src/app/services/membership-type.service';

@Component({
  selector: 'app-membership-type-dialog',
  templateUrl: './membership-type-dialog.component.html',
  styleUrls: ['./membership-type-dialog.component.scss']
})
export class MembershipTypeDialogComponent implements OnInit {

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() membershipType:MembershipType;
  @Input() mode:string;

  constructor(private membershipTypeService:MembershipTypeService) { }

  ngOnInit(): void {
    if(this.mode === 'a'){
      this.membershipType = {membershipTypeId:null,
                            name:null,
                            numberOfGroupTrainings:null,
                            numberOfTrainings:null,
                              price:null,
                            priceId:null,
                          productId:null}
    }
  }



  closeDialog(){
    this.deleteItself.emit();
  }

  submit(){

    if(this.mode === 'm'){

      this.membershipTypeService.putMembershipType(this.membershipType).subscribe(m =>{

      });
    }else if(this.mode === 'a'){
      this.membershipTypeService.postMembershipType(this.membershipType).subscribe(m =>{

      });
    }
    this.closeDialog();
  }
}
