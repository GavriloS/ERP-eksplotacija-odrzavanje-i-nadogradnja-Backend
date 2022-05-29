import { EquipmentType } from "./EquipmentType.model";

export interface Equipment{
  equipmentId:string,
  name: string,
  description: string,
  manufacturer: string,
  quantity: number,
  price: number,
  equipmentTypeId:string,
  equipmentType: EquipmentType,
  priceId:string,
  productId:string
}
