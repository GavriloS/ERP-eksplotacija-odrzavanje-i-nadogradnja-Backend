import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Subscription, switchMap } from 'rxjs';
import { Equipment } from 'src/app/models/Equipment.model';
import { Suplement } from 'src/app/models/Suplement.model';
import { EquipmentService } from 'src/app/services/equipment.service';
import { SuplementService } from 'src/app/services/suplement.service';

@Component({
  selector: 'app-add-quantity',
  templateUrl: './add-quantity.component.html',
  styleUrls: ['./add-quantity.component.scss']
})
export class AddQuantityComponent implements OnInit,OnDestroy {
  paramSubscription:Subscription;
  id:string;
  type:string;
  quantity:number = 1;
  suplement:Suplement;
  equipment:Equipment;
  public name:string;

  constructor(private route:ActivatedRoute,
              private equipmentService:EquipmentService,
              private suplementService:SuplementService,
              private router:Router) { }

  ngOnInit(): void {
    this.paramSubscription =  this.route.queryParams.pipe(switchMap((p,i) =>{
      this.type = p['type'];
      return this.route.paramMap
     })).subscribe((paraMap:ParamMap) =>{
       if(paraMap.has("id")){
         this.id = paraMap.get("id");
         console.log(this.id)
         this.loadProduct();
       }
     });
  }
  loadProduct(){
    switch(this.type){
      case 'e':
        this.equipmentService.getEquipmentById(this.id).subscribe(equipment =>{
          this.equipment = equipment;
          this.name = equipment.name;

        });
        break;
      case 's':
        this.suplementService.getSuplementById(this.id).subscribe(suplement =>{
          this.suplement = suplement;
          this.name = suplement.name;
        })
      break;
    }
  }

  addQuantity(){
    switch(this.type){
      case 'e':
          this.equipment.quantity += this.quantity;
          this.equipmentService.modifyEquipment(this.equipment).subscribe(e =>{
            console.log(e);
          }).unsubscribe();
          this.router.navigate(['/']);
        break;
      case 's':
        this.suplement.quantity +=this.quantity;
        this.suplementService.modifySuplement(this.suplement).subscribe(s => {
          console.log(s);
        });

      break;
    }
  }

  ngOnDestroy(): void {
    this.paramSubscription.unsubscribe();
}
}
