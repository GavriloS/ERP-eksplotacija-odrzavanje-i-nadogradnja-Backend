import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MembershipType } from '../models/membershipType.model';

@Injectable({
  providedIn: 'root'
})
export class MembershipTypeService {

  constructor(private http:HttpClient) { }

  url = environment.backendUrl + "api/membershipType/"
  membershipTypes:MembershipType[] = [];


  getMembershipTypes(){

    return this.http.get<MembershipType[]>(this.url);
  }

  postMembershipType(membershipType:MembershipType){
    console.log(membershipType)
    return this.http.post<MembershipType>(this.url,membershipType);
  }

  putMembershipType(membershipType:MembershipType){
    return this.http.put<MembershipType>(this.url,membershipType);
  }

  deleteMembershipType(id:string){
    return this.http.delete(this.url+id);
  }
}
