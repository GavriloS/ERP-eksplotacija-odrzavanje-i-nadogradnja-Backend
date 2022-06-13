import { Suplement } from "./Suplement.model";

export interface BasketSuplement{
  basketId:string,
  suplement:Suplement,
  quantity:number;
}
