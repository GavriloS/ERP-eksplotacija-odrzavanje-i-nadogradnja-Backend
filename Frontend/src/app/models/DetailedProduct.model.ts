export class DetailedProduct{

  constructor(){}
  public id:string;
  public name: string;
  public description: string;
  public manufacturer: string;
  public quantity: number;
  public price: number;
  public typeId: string;
  public typeName: string;
  public productId:string;
  public priceId:string;

  clone(){
    let product = new DetailedProduct();
    product.id= this.id;
    product.name = this.name;
    product.description = this.description;
    product.price = this.price;
    product.quantity = this.quantity;
    product.typeId = this.typeId;
    product.typeName = this.typeName;
    product.manufacturer = this.manufacturer;
    product.priceId = this.priceId;
    product.productId = this.productId
    return product;

  }
}
