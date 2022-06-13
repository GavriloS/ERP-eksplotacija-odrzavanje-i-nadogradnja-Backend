import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GroupTrainingType } from '../models/GroupTrainingType.model';

@Injectable({
  providedIn: 'root'
})
export class GroupTrainingTypeService {

  constructor(private http:HttpClient) { }

  url = environment.backendUrl+"api/groupTrainingType/"
  getGroupTrainingTypes(){
    return this.http.get<GroupTrainingType[]>(this.url);
  }

  modifyGroupTrainingType(groupTrainingType:GroupTrainingType){
    return this.http.put<GroupTrainingType>(this.url,groupTrainingType);
  }

  addGroupTrainingType(grouptraining:GroupTrainingType){
    return this.http.post<GroupTrainingType>(this.url,grouptraining);
  }
  deleteGroupTrainingType(id:string){
    return this.http.delete(this.url+id);
  }
}
