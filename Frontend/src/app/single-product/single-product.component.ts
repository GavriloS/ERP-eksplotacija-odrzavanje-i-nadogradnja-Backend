import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Params, Router } from '@angular/router';
import { Subscription, switchMap } from 'rxjs';
import { DetailedProduct } from '../models/DetailedProduct.model';
import { ProductCardComponent } from '../product-page/product-card/product-card.component';
import { AuthService } from '../services/auth.service';
import { EquipmentService } from '../services/equipment.service';
import { SuplementService } from '../services/suplement.service';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.scss']
})
export class SingleProductComponent implements OnInit, OnDestroy {

  role:string;
  paramSubscription:Subscription;
  id:string;
  type:string;
  product:DetailedProduct = new DetailedProduct();

  quantity:number = 1;

  constructor(private route: ActivatedRoute,
              private equipmentService:EquipmentService,
              private suplementService:SuplementService,
              private authService:AuthService,
              private router:Router) { }



  ngOnInit(): void {

   this.paramSubscription =  this.route.queryParams.pipe(switchMap((p,i) =>{
     this.type = p['type'];
     return this.route.paramMap
    })).subscribe((paraMap:ParamMap) =>{
      if(paraMap.has("prodId")){
        this.id = paraMap.get("prodId");
        console.log(this.id)
        this.loadProduct();
        this.role = this.authService.role;
      }
    });

  }

  ngOnDestroy(): void {
      this.paramSubscription.unsubscribe();
  }

  loadProduct(){
    switch(this.type){
      case 'e':
        this.equipmentService.getEquipmentById(this.id).subscribe(equipment =>{
          this.product = this.equipmentService.equipmentToDetailedProduct(equipment);

        });
        break;
      case 's':
        this.suplementService.getSuplementById(this.id).subscribe(suplement =>{
          this.product = this.suplementService.suplementToDetailedProduct(suplement);
        })
      break;
    }
  }

  addToCart(){
    this.authService.addProductToBasket(this.product,this.type,this.quantity);
    this.router.navigate(['/basket']);

  }
}
