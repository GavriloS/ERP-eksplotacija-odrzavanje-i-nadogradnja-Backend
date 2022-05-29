import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GroupTrainingType } from '../models/GroupTrainingType.model';

@Injectable({
  providedIn: 'root'
})
export class GroupTrainingTypeService {

  constructor(private http:HttpClient) { }

  getGroupTrainingTypes(){
    return this.http.get<GroupTrainingType[]>('http://localhost:5189/api/groupTrainingType');
  }
}
