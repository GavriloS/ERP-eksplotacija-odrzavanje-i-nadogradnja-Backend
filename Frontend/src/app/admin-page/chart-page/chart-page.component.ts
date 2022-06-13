import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-chart-page',
  templateUrl: './chart-page.component.html',
  styleUrls: ['./chart-page.component.scss']
})
export class ChartPageComponent implements OnInit {

  basicData: any;

  basicOptions: any;


  constructor(private basketService:BasketService) { }

  ngOnInit(): void {
  this.basketService.getProductCountPerMonth().subscribe(p =>{
    this.basicData = {
      labels: ['Januar', 'Februar', 'Mart', 'April', 'Maj', 'Jun', 'Jul','Avgust','Septembar','Oktobar','Novembar','Decembar'],
      datasets: [
          {
              label: 'Equipments',
              backgroundColor: '#42A5F5',
              data: p.equipments
          },
          {
              label: 'Suplements',
              backgroundColor: '#FFA726',
              data: p.suplements
          }
      ]
  };
  })
  }

}
