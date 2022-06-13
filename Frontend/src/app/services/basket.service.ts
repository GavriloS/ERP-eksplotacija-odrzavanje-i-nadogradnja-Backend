import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Basket } from '../models/Basket.model';
import { BasketDb } from '../models/BasketDb.model';
import { ProductPerMonth } from '../models/ProductPerMonth.model';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private http:HttpClient) { }

  url:string = environment.backendUrl+"api/basket/";

  getOpenBasket(userId:string){
    return this.http.get<Basket>(this.url+userId);
  }

  getBaskets(){
    return this.http.get<BasketDb[]>(this.url);
  }

  getBasketByUser(userId:string){
    return this.http.get<BasketDb[]>(this.url+"user/"+userId);
  }

  // postBasket(basket:Basket){

  //   let postBasket:{  dateTimeOfPurchase: Date,
  //   userId: string,
  //   isCompleted: boolean,
  //   equipmentIds:Record<string,number>,
  //   suplementIds: Record<string,number>} = {
  //     userId: basket.userId,
  //     isCompleted:true,
  //     dateTimeOfPurchase:new Date(),
  //     equipmentIds:{},
  //     suplementIds:{}
  //   };
  //   basket.equipments.forEach(e => {
  //     postBasket.equipmentIds[e.id] = e.quantity;
  //   });
  //   basket.suplements.forEach(s =>{
  //     postBasket.suplementIds[s.id] = s.quantity
  //   })

  //   return this.http.post<Basket>('http://localhost:5189/api/basket',postBasket);
  // }

  getProductCountPerMonth(){
    return this.http.get<ProductPerMonth>('http://localhost:5189/api/basket/productCountPerMonth');
  }



}
