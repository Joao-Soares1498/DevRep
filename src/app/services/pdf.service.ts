import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PdfService {

  private baseUrl: string = "https://localhost:7007/api/Docs/"
  constructor(private http: HttpClient) { }

  //calls back end pdf function in back end
  pdf(anualPdfObj:any){
    return this.http.post<any>(`${this.baseUrl}pdf`,anualPdfObj);
  }
}
