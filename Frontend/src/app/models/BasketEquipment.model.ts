import { Equipment } from "./Equipment.model";

export interface BasketEquipment{
  basketId:string,
  equipment:Equipment,
  quantity:number
}
