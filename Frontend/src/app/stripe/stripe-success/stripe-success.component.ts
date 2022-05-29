import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-stripe-success',
  templateUrl: './stripe-success.component.html',
  styleUrls: ['./stripe-success.component.scss']
})
export class StripeSuccessComponent implements OnInit {

  constructor(private authService:AuthService,
              private basketService:BasketService) { }

  ngOnInit(): void {
    console.log("komponenta");
    this.authService.basket.dateTimeOfPurchase = new Date();
    console.log(new Date());
    this.basketService.postBasket(this.authService.basket).subscribe(b => {
          console.log("Kupljeno")
      this.authService.basket.equipments = []
      this.authService.basket.suplements = []
    })

  }

}
