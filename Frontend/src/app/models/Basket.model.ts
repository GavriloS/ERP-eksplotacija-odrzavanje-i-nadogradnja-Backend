import { DetailedProduct } from "./DetailedProduct.model"
import { Product } from "./Product.model"
import { User } from "./User.model"

export interface Basket{

    basketId: string,
    dateTimeOfPurchase: Date,
    user: User,
    userId:string,
    isCompleted: boolean,
    products:DetailedProduct[]

}
