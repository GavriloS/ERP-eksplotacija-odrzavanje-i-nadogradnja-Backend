import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Subject } from 'rxjs';
import { Basket } from '../models/Basket.model';
import { DetailedProduct } from '../models/DetailedProduct.model';
import { User } from '../models/User.model';
import { BasketService } from './basket.service';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user = new Subject<User>();
  private token:string;
  private tokenExpirationTimer: any;
  public basket:Basket;
  public role:string = '';


  constructor(private http: HttpClient,private router: Router,
              private basketService:BasketService) { }

  signIn(email:string,password:string){
    this.http.post<{token:string,user:User,expiresIn:number}>(
      'http://localhost:5189/api/auth/authorize',
      {email:email,
        password:password}
    ).subscribe(res =>{
      let expires = new Date(new Date().getTime() + res.expiresIn*1000);
      let user = new User(
        res.user.userId,
        res.user.firstName,
        res.user.lastName,
        res.user.email,
        null,
        res.user.contactNumber,
        res.user.numberOfTrainings,
        res.user.numberOfGroupTraings,
        null,
        null,
        null,
        res.user.userType,
        res.token,
        expires
      );
      //RIght now i dont store not finished baskets
      // this.basketService.getOpenBasket(user.userId).subscribe(b =>{
      //   if(!!b){
      //     this.basket = b;

      //   }
      //   this.basket.user = user;
      //   this.basket.userId = user.userId
      // }).unsubscribe()
      this.basket = {equipments:[],suplements:[],basketId:null,dateTimeOfPurchase:null,user:user,userId:user.userId,isCompleted:false}
      this.user.next(user);
      this.autoLogout(res.expiresIn * 1000)
      this.token = res.token;
      this.role = JSON.parse(atob(this.token.split('.')[1]))['role']

      localStorage.setItem("userData",JSON.stringify(user));
      this.router.navigate(["/"]);
    })
  };

  signUp(user:User){
    this.http.post(
      'http://localhost:5189/api/auth/register',
      user
    ).subscribe({
      next: res =>{
      alert("Uspešno registrovan korisnik");
      this.router.navigate(["/"]);
    },
    error:err =>{
      alert("Unesen korisnik vec postoji");
    }});
  }

  logout(){
    this.user.next(null);
    this.token = null;
    this.role = '';
    localStorage.removeItem("userData");
    localStorage.removeItem("basketData");
    this.basket = null;
    if (this.tokenExpirationTimer) {
      clearTimeout(this.tokenExpirationTimer);
    }
    this.tokenExpirationTimer = null;
    this.router.navigate(["/login"])
  }

  autoLogin(){
    const userData:{
      userId:string,
      firstName:string,
      lastName:string,
      email:string
      contactNumber:string,
      numberOfGroupTrainings:string,
      numberOfTrainings:string,
      _token:string,
      _tokenExpirationDate:string,
      userType:{
        userTypeId:string,
        name:string
      }
    } = JSON.parse(localStorage.getItem("userData"));
    if(!userData){
      return;
    }
    const loadedUser = new User(
      userData.userId,
      userData.firstName,
      userData.lastName,
      userData.email,
      null,
      userData.contactNumber,
      +userData.numberOfTrainings,
      +userData.numberOfGroupTrainings,
      null,
      null,
      null,
      null,
      userData._token,
      new Date(userData._tokenExpirationDate)
    );
    if(loadedUser.getToken()){
      this.user.next(loadedUser);
      this.token = userData._token
      this.role = JSON.parse(atob(this.token.split('.')[1]))['role']
      const expirationDuration =
      new Date(userData._tokenExpirationDate).getTime() -
      new Date().getTime();
    this.autoLogout(expirationDuration);

      const basektData:Basket = JSON.parse(localStorage.getItem('basketData'));
      if(!!basektData){
      this.basket = basektData;
      console.log("basket");
      console.log(this.basket);
      }
    }
  }

  autoLogout(expirationDuration: number) {
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }

  getToken(){
    return this.token;
  }

  addProductToBasket(product:DetailedProduct,type:string,quantity:number){
    let isIn:boolean = false;
    switch(type){
      case 'e':



        this.basket.equipments.forEach(e =>{
          if(e.id == product.id){
            e.quantity += quantity
            isIn = true;
          }
        });
        if(!isIn){
          let p = product.clone();
          p.quantity = quantity;
          this.basket.equipments.push(p)
        }

        break;
      case 's':
        this.basket.suplements.forEach(s => {
          if(s.id == product.id){
            s.quantity += quantity;
            isIn = true

          }
        })
        if(!isIn){
          let p = product.clone();
          p.quantity = quantity;
          this.basket.suplements.push(p);
        }
        break;
    }

    localStorage.setItem('basketData',JSON.stringify(this.basket));
  }

}
