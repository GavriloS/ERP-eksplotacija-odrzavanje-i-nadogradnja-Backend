import { Component, OnDestroy, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Subscription } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit,OnDestroy {

  private userSub:Subscription;
  isAuthenticated:boolean;
  role:string = '';

  constructor(private authService:AuthService) { }

  items: MenuItem[];
  ngOnInit(): void {
    this.isAuthenticated = !!this.authService.getToken()
    if(!!this.authService.getToken()){


      this.role = JSON.parse(atob(this.authService.getToken().split('.')[1]))['role'];
    }
    this.userSub = this.authService.user.subscribe(user =>{

      this.isAuthenticated = !!user;
      if(!!user){
        this.role = JSON.parse(atob(user.getToken().split('.')[1]))['role'];
        this.authService.role = this.role;
      }else{
        this.role = ''
        this.authService.role = '';
      }
    });
  }

  onLogout(){
    this.authService.logout();
  }
  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }
}
