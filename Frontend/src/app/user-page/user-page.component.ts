import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../models/User.model';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit, OnDestroy {


  user:User;
  userSubscription:Subscription
  role:string;
  constructor(private authService:AuthService) { }

  ngOnInit(): void {
    this.user = this.authService.user.value
    this.role = this.authService.role;
    this.userSubscription = this.authService.user.subscribe( u =>{
      if(!!u){
        this.user = u;
        this.role = this.authService.role;
         }
    });
  }

  ngOnDestroy(): void {
      this.userSubscription.unsubscribe();
  }



}
