import { tokenize } from "@angular/compiler/src/ml_parser/lexer";
import { Address } from "./Address.model";
import { UserType } from "./UserType.model";

export class User{

  constructor(public userId:string,public firstName:string,
    public lastName:string,
    public email:string,
    public password:string,
    public contactNumber:string,
    public numberOfTrainings:number,
    public numberOfGroupTraings:number,
    public addressId:string,
    public address:Address,
    public userTypeId:string,
    public userType:UserType,
    private _token:string,
    private _tokenExpirationDate:Date
    ){}

    getToken(){
        if(!this._tokenExpirationDate || new Date() > this._tokenExpirationDate){
          return null;
        }
        return this._token;
    }

    setToken(token:string){
      this._token = token;

    }
    setTokenExpirationDate(expirationDate:Date){
      this._tokenExpirationDate = expirationDate;
    }

}

