import { Component, Input, OnInit } from '@angular/core';
import { BasketDb } from 'src/app/models/BasketDb.model';
import { User } from 'src/app/models/User.model';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-basket-table',
  templateUrl: './basket-table.component.html',
  styleUrls: ['./basket-table.component.scss']
})
export class BasketTableComponent implements OnInit {

  baskets:BasketDb[] = [];
  selectedBasket:BasketDb;
  @Input() user:User;
  headers:string[] = ['Datum','Cena']
  constructor(private basketService:BasketService) { }

  showBasketDialog:boolean = false;
  ngOnInit(): void {
    this.basketService.getBasketByUser(this.user.userId).subscribe(b =>{
      this.baskets.push(...b);
    });
  }

  getBasketPrice(basket:BasketDb){
    let price:number = 0;
    basket.equipments.forEach(e =>{
      price += e.quantity * e.equipment.price
    });
    basket.suplements.forEach(s =>{
      price += s.quantity * s.suplement.price
    });
    return price;
  }

  openDialog(basket:BasketDb){
    this.selectedBasket = basket;
    this.showBasketDialog = true;
  }
  closeDialog(){
    this.showBasketDialog = false;
  }
}
