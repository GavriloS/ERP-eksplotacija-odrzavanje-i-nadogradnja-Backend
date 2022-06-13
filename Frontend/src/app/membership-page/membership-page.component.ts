import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MembershipType } from '../models/membershipType.model';
import { AuthService } from '../services/auth.service';
import { MembershipTypeService } from '../services/membership-type.service';
import { StripeService } from '../services/stripe.service';

@Component({
  selector: 'app-membership-page',
  templateUrl: './membership-page.component.html',
  styleUrls: ['./membership-page.component.scss']
})
export class MembershipPageComponent implements OnInit {

  constructor(private membershipTypeService:MembershipTypeService,
              private stripeService:StripeService,
              private authService:AuthService,
              private router:Router) { }
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


  buyMembership(membershipType:MembershipType){

      let user = this.authService.user.value;
      if(!!user){


      let m:Record<string,number> = {};
      m[membershipType.priceId] = 1;

      this.stripeService.requestMemberSessionMembership(m,user.userId);
      }else{
          this.router.navigate(["/login"]);
      }
  }


}
