import { SuplementType } from "./SuplementType.model";

export interface Suplement{

  suplementId: string,
  name: string,
  description: string,
  manufacturer: string,
  quantity: number,
  price: number,
  suplementTypeId: string,
  suplementType: SuplementType,
  priceId:string,
  productId:string
}
