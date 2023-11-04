import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DocxService {

  private baseUrl :string = "https://localhost:7007/api/Docs/"

  constructor(private http: HttpClient) { }

  //calls back end docx function in back end
  docx(docxObj:any){
    return this.http.post<any>(`${this.baseUrl}docx`, docxObj)
  }
}
