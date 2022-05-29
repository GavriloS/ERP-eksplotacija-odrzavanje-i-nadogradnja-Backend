import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MembershipType } from '../models/membershipType.model';

@Injectable({
  providedIn: 'root'
})
export class MembershipTypeService {

  constructor(private http:HttpClient) { }


  membershipTypes:MembershipType[] = [];


  getMembershipTypes(){

    return this.http.get<MembershipType[]>(
      'http://localhost:5189/api/membershipType'
    );
  }

}
