import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-success-membership',
  templateUrl: './success-membership.component.html',
  styleUrls: ['./success-membership.component.scss']
})
export class SuccessMembershipComponent implements OnInit {

  constructor(private userService:UserService,
              private route:ActivatedRoute,
              private authService:AuthService) { }


  ngOnInit(): void {
    this.route.paramMap.subscribe((paramMap: ParamMap) => {
      if (paramMap.has("id")) {

        this.userService.getUserById(paramMap.get("id")).subscribe(u =>{

            let user = this.authService.user.value
            user.numberOfGroupTraings = u.numberOfGroupTraings;
            user.numberOfTrainings = u.numberOfTrainings;
            this.authService.user.next(user);


        });
      }
    })


   }



}
