import { Component, OnInit } from '@angular/core';
import { Basket } from '../models/Basket.model';
import { DetailedProduct } from '../models/DetailedProduct.model';
import { AuthService } from '../services/auth.service';
import { StripeService } from '../services/stripe.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  constructor(private authService:AuthService,
              private stripeService:StripeService) { }

  basket:Basket;
  ngOnInit(): void {
    if(!!this.authService.basket){
      this.basket = this.authService.basket;
    }else{
      this.basket = {basketId:null,userId:this.authService.user.value.userId,products:[],isCompleted:false,dateTimeOfPurchase:null,user:this.authService.user.value}
    }
  }

  //Put everything in product array
  getTotalPrice(){
    let totalPrice:number = 0
    for(let i = 0; i< this.basket.products.length;i++){
        totalPrice += this.basket.products[i].price * this.basket.products[i].quantity
    }
  return totalPrice;
  }

  proceedToPayment(){
    let rec:Record<string,number> = {}

    this.basket.products.forEach(p =>{
      rec[p.priceId] = p.quantity;
    })



    this.stripeService.requestMemberSession(rec);
  }

  removeProduct(p:DetailedProduct){
    this.basket.products.forEach((item, index) => {
      if(item.id === p.id) this.basket.products.splice(index,1);
    });
  }

}
