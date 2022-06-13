import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DetailedProduct } from '../models/DetailedProduct.model';
import { Product } from '../models/Product.model';
import { Suplement } from '../models/Suplement.model';

@Injectable({
  providedIn: 'root'
})
export class SuplementService {

  constructor(private http:HttpClient) { }


  getSuplements(resultPerPage:number,currentPage:number,name:string,orderBy:string,typeId:string){
    let queryParams = `?results=${resultPerPage}&page=${currentPage}&orderBy=${orderBy}`;
    if(!!name){
      queryParams+=`&name=${name}`
    }
    if(!!typeId){
      queryParams+= `&typeId=${typeId}`
    }

    return this.http.get<{suplements:Product[],currentPage:number,totalPages:number}>('http://localhost:5189/api/suplement'+queryParams)

  }

  getSuplementById(id:string){
    return this.http.get<Suplement>('http://localhost:5189/api/suplement/'+id)
  }

  suplementToDetailedProduct(suplement:Suplement){
    let product = new DetailedProduct();
    product.id= suplement.suplementId;
    product.name = suplement.name;
    product.description = suplement.description;
    product.price = suplement.price;
    product.quantity = suplement.quantity;
    product.typeId = suplement.suplementTypeId;
    product.typeName = suplement.suplementType.name;
    product.manufacturer = suplement.manufacturer;
    product.priceId = suplement.priceId;
    product.productId = suplement.productId;
    return product;
  }

  modifySuplement(suplement:Suplement){
    console.log(suplement);
    return this.http.put<Suplement>('http://localhost:5189/api/suplement/',suplement);
  }
  getEquipmentsAdmin(){
    return this.http.get<Suplement[]>('http://localhost:5189/api/suplement/admin');
  }
  addEquipment(suplement:Suplement){
    return this.http.post<Suplement>('http://localhost:5189/api/suplement/',suplement);
  }

  deleteSuplement(id:string){
    return this.http.delete('http://localhost:5189/api/suplement/'+id);
  }
}
