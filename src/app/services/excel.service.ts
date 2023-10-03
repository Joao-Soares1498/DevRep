import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ExcelService {

  private baseUrl : string = "https://localhost:7007/api/Docs/"
  constructor(private http: HttpClient) { }

  //calls back end excel function in back end
  excel(anualExcelObj:any){
    return this.http.post<any>(`${this.baseUrl}excel`,anualExcelObj)
  }
}
