import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-stripe-success',
  templateUrl: './stripe-success.component.html',
  styleUrls: ['./stripe-success.component.scss']
})
export class StripeSuccessComponent implements OnInit {

  constructor(private authService:AuthService) { }

  ngOnInit(): void {

    this.authService.basket.products = []


  }

}
