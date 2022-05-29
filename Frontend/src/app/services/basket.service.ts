import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Basket } from '../models/Basket.model';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private http:HttpClient) { }


  getOpenBasket(userId:string){
    return this.http.get<Basket>('http://localhost:5189/api/basket/user/'+userId);
  }

  postBasket(basket:Basket){

    let postBasket:{  dateTimeOfPurchase: Date,
    userId: string,
    isCompleted: boolean,
    equipmentIds:Record<string,number>,
    suplementIds: Record<string,number>} = {
      userId: basket.userId,
      isCompleted:true,
      dateTimeOfPurchase:new Date(),
      equipmentIds:{},
      suplementIds:{}
    };
    basket.equipments.forEach(e => {
      postBasket.equipmentIds[e.id] = e.quantity;
    });
    basket.suplements.forEach(s =>{
      postBasket.suplementIds[s.id] = s.quantity
    })

    return this.http.post<Basket>('http://localhost:5189/api/basket',postBasket);
  }




}
