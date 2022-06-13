import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/User.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  url = environment.backendUrl+"api/user/"
  getUserById(userId:string){
    return this.http.get<User>(this.url + userId);
  }

  getUsers(){
    return this.http.get<User[]>(this.url);
  }


  getTrainers(){
    return this.http.get<User[]>(this.url+'trainers');
  }

  addUser(user:User){
    return this.http.post<User>(this.url,user);
  }

  modifyUser(user:User){
    return this.http.put<User>(this.url,user);
  }
}
