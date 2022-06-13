import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EquipmentType } from '../models/EquipmentType.model';

@Injectable({
  providedIn: 'root'
})
export class EquipmentTypeService {

  constructor(private http:HttpClient) { }
  backendUrl: string = environment.backendUrl +'api/equipmentType/';
  getEquipmentTypes(){
    return this.http.get<EquipmentType[]>(this.backendUrl);
  }
  modifyEquipmentType(equipmentType:EquipmentType){
    return this.http.put(this.backendUrl,equipmentType);
  }
  addEquipmentType(equipmentType:EquipmentType){
    return this.http.post(this.backendUrl,equipmentType);
  }
  deleteEquipmentType(id:string){
    return this.http.delete(this.backendUrl + id );
  }
}
