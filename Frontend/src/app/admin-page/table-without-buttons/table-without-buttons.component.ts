import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { map } from 'rxjs';
import { BasketService } from 'src/app/services/basket.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-table-without-buttons',
  templateUrl: './table-without-buttons.component.html',
  styleUrls: ['./table-without-buttons.component.scss']
})
export class TableWithoutButtonsComponent implements OnInit,OnChanges {

  @Input() tableName:string;

  tableInput:any;
  headers:any;

  element:any

  basketTableNames:string[] = ['basketId','dateTimeOfPurchase','userId']
  trainerTableNames:string[] =['firstName','lastName','contactNumber','email']


  showBasketDialog:boolean = false;
  showUserDialog:boolean = false;

  constructor(private basketService:BasketService,
              private userService:UserService) { }

  ngOnInit(): void {
    this.updateTable(this.tableName);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateTable(changes['tableName'].currentValue);
  }

  updateTable(tableName:string){
    switch(tableName){
        case 'Basket':
          this.basketService.getBaskets().pipe(map(b => {

            b.forEach(basket =>{
              basket.userId = basket.user.userId;
            })
            return b
          })).subscribe(b =>{
            this.tableInput = b;
            this.headers = this.basketTableNames;
          });
          break;
        case 'Trainer':
          this.userService.getTrainers().subscribe(u =>{
            this.tableInput = u;
            this.headers = this.trainerTableNames;
          })
          break;
    }
  }

  closeDialog(){
    this.showBasketDialog = false;
    this.showUserDialog = false;
  }

  openDialog(element:any){
    this.element = element;
    this.showBasketDialog = true;
  }


  addRow(){
    this.showUserDialog = true;
  }
}
