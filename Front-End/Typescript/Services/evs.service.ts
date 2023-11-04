import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EvsService {

  private baseUrl = "https://localhost:7007/api/Docs/"
  constructor(private http:HttpClient) { }

  getEvs(nameid: string){
    return this.http.get<any>(`${this.baseUrl}getEvs?nameid=${nameid}`);
  }


  postEvs(anualEvObj:any){
    return this.http.post<any>(`${this.baseUrl}saveEv`,anualEvObj);
  }

  getEvData(id:any){
    return this.http.get<any>(`${this.baseUrl}getEvData?id=${id}`);
  }
}
