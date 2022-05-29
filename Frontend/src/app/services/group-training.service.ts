import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GroupTrainingType } from '../models/GroupTrainingType.model';

@Injectable({
  providedIn: 'root'
})
export class GroupTrainingService {

  constructor(private http:HttpClient) { }

  getGroupTrainings(){
    return this.http.get<GroupTrainingType[]>('http://localhost:5189/api/groupTrainingType');
  }
}
