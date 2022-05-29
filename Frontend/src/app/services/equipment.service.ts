import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DetailedProduct } from '../models/DetailedProduct.model';
import { Equipment } from '../models/Equipment.model';
import { Product } from '../models/Product.model';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

  constructor(private http:HttpClient) { }


  getEquipments(resultPerPage:number,currentPage:number,name:string){
    let queryParams = `?results=${resultPerPage}&page=${currentPage}`;
    if(!!name){
      queryParams+=`&name=${name}`
    }
    return this.http.get<{equipments:Product[],currentPage:number,totalPages:number}>('http://localhost:5189/api/equipment'+queryParams)

  }

  getEquipmentById(id:string){
    return this.http.get<Equipment>('http://localhost:5189/api/equipment/'+id)
  }

  equipmentToDetailedProduct(equipment:Equipment){
          let product = new DetailedProduct();
          product.id= equipment.equipmentId;
          product.name = equipment.name;
          product.description = equipment.description;
          product.price = equipment.price;
          product.quantity = equipment.quantity;
          product.typeId = equipment.equipmentTypeId;
          product.typeName = equipment.equipmentType.name;
          product.manufacturer = equipment.manufacturer;
          product.priceId = equipment.priceId;
          product.productId = equipment.productId;
          return product;
  }

  modifyEquipment(equipment:Equipment){
    console.log(equipment);
    return this.http.put<Equipment>('http://localhost:5189/api/equipment/',equipment);
  }
}
