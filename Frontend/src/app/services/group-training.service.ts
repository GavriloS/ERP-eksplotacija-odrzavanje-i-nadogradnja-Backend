import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GroupTraining } from '../models/GroupTraining.model';
import { GroupTrainingType } from '../models/GroupTrainingType.model';

@Injectable({
  providedIn: 'root'
})
export class GroupTrainingService {

  constructor(private http:HttpClient) { }

  url = environment.backendUrl + 'api/groupTraining/'
  getGroupTrainings(){
    return this.http.get<GroupTraining[]>(this.url);
  }

  modifyGroupTraining(groupTraining:GroupTraining){
    return this.http.put<GroupTraining>(this.url,groupTraining);
  }

  addGroupTraining(groupTraining:GroupTraining){
    return this.http.post<GroupTraining>(this.url,groupTraining);
  }

  deleteGroupTraining(id:string){
    return this.http.delete(this.url+id);
  }

  addUserToGroupTraining(groupTrainingId:string,userId:string){
    return this.http.get<GroupTraining>(this.url+groupTrainingId+'/'+userId);
  }
  deleteUserFromGroupTraining(groupTrainingId:string,userId:string){
    return this.http.delete<GroupTraining>(this.url+groupTrainingId+'/'+userId);
  }
  getGroupTrainingByTrainer(trainierId:string){
    return this.http.get<GroupTraining[]>(this.url+'trainer/'+trainierId);
  }





}
