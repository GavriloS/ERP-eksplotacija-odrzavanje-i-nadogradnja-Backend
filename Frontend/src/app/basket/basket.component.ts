import { Component, OnInit } from '@angular/core';
import { Basket } from '../models/Basket.model';
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
    }
  }

  //Put everything in product array
  getTotalPrice(){
    let totalPrice:number = 0
    for(let i = 0; i< this.basket.equipments.length;i++){
        totalPrice += this.basket.equipments[i].price * this.basket.equipments[i].quantity
    }
    for(let i = 0; i< this.basket.suplements.length;i++){
      totalPrice += this.basket.suplements[i].price * this.basket.suplements[i].quantity
  }
  return totalPrice;
  }

  proceedToPayment(){
    let rec:Record<string,number> = {}

    this.basket.equipments.forEach(e =>{
      rec[e.priceId] = e.quantity;
    })

    this.basket.suplements.forEach(s => {
      rec[s.priceId] = s.quantity;

    })

    this.stripeService.requestMemberSession(rec);
  }

}
