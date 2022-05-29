import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Address } from '../models/Address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http:HttpClient) { }


  addAddress(address:Address){
      return this.http.post<Address>('http://localhost:5189/api/address',address);
  }
}
