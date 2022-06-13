import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BasketDb } from 'src/app/models/BasketDb.model';

@Component({
  selector: 'app-basket-dialog',
  templateUrl: './basket-dialog.component.html',
  styleUrls: ['./basket-dialog.component.scss']
})
export class BasketDialogComponent implements OnInit {

  @Input() showDialog:boolean;
  @Output() deleteItself = new EventEmitter();
  @Input() basket:BasketDb;



  constructor() { }

  ngOnInit(): void {
  }

  closeDialog(){
    this.deleteItself.emit();
  }

  getTotalPrice(){
    let price:number = 0;
    this.basket.equipments.forEach(e =>{
      price += e.equipment.price * e.quantity;
    })
    this.basket.suplements.forEach(s =>{
      price += s.suplement.price * s.quantity;
    })
    this.basket.dateTimeOfPurchase.toDateString


    return price
  }


}
