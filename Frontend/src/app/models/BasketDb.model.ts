import { BasketEquipment } from "./BasketEquipment.model";
import { BasketSuplement } from "./BasketSuplement.model";
import { User } from "./User.model";

export interface BasketDb{
  basketId:string,
  dateTimeOfPurchase:Date,
  user:User,
  userId:string,
  equipments: BasketEquipment[],
  suplements:BasketSuplement[]
}
