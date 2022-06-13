import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SuplementType } from '../models/SuplementType.model';

@Injectable({
  providedIn: 'root'
})
export class SuplementTypeService {

  backendUrl: string = environment.backendUrl +'api/suplementType/';

  constructor(private http:HttpClient) { }

  getSuplementTypes(){
    return this.http.get<SuplementType[]>(this.backendUrl);
  }

  modifySuplementType(suplementType:SuplementType){
    return this.http.put<SuplementType>(this.backendUrl,suplementType);
  }
  addSuplementType(suplementType:SuplementType){
    return this.http.post<SuplementType>(this.backendUrl,suplementType);
  }

  deleteSuplementType(id:string){
    return this.http.delete(this.backendUrl+id);
  }


}
