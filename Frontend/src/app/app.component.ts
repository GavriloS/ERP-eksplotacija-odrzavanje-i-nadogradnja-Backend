import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PrimeNGConfig } from 'primeng/api';
import { Subscription } from 'rxjs';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  role:string;
  userSub:Subscription;
  constructor(private authService:AuthService,
             private primengConfig: PrimeNGConfig,
             private router:Router){}
  ngOnInit(): void {
    this.authService.autoLogin();
    this.role = this.authService.role;
    this.userSub = this.authService.user.subscribe(user =>{


      if(!!user){
        this.role = JSON.parse(atob(user.getToken().split('.')[1]))['role'];
        this.authService.role = this.role;
      }else{
        this.role = ''
        this.authService.role = '';
      }
    });
    if(this.role ==='admin'){
      this.router.navigate(['/admin'])

    }
    this.primengConfig.ripple = true;
  }



}
