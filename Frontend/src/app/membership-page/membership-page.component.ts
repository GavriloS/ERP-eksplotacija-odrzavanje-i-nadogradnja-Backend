import { Component, OnInit } from '@angular/core';
import { MembershipType } from '../models/membershipType.model';
import { MembershipTypeService } from '../services/membership-type.service';

@Component({
  selector: 'app-membership-page',
  templateUrl: './membership-page.component.html',
  styleUrls: ['./membership-page.component.scss']
})
export class MembershipPageComponent implements OnInit {

  constructor(private membershipTypeService:MembershipTypeService) { }
  membershipTypes:MembershipType[] = [];
  membershipTypesMix:MembershipType[] = [];
  membershipTypesTraining:MembershipType[] = [];
  membershipTypesGroupTraining:MembershipType[] = [];

  ngOnInit(): void {



    this.membershipTypeService.getMembershipTypes()
    .subscribe(res =>{

      res.forEach(mType => {
        let hasTrainings:Boolean = false;
        let hasGroupTrainings:Boolean = false;
        if(mType.numberOfGroupTrainings > 0){
          hasGroupTrainings = true;
        }
        if(mType.numberOfTrainings > 0){
          hasTrainings = true;
        }
        if(hasGroupTrainings && hasTrainings){
          this.membershipTypesMix.push(mType);

        }else if(hasGroupTrainings){
          this.membershipTypesGroupTraining.push(mType);
        }else if(hasTrainings){
          this.membershipTypesTraining.push(mType);
        }



      });

    })

  }


}
