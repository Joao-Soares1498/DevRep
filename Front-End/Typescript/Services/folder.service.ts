import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FolderService {

  private baseUrl:string = "https://localhost:7007/api/Docs/"

  constructor(private http:HttpClient) { }

  //calls back end folders function in back end
  getFolders(nameid: string) {
    return this.http.get<any[]>(`${this.baseUrl}folders?nameid=${nameid}`);
  }

  //calls back end download function in back end
  downloadFile(nameid: string, folderName: string, fileName: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });


    return this.http.get(`${this.baseUrl}download?nameid=${nameid}&folderName=${folderName}&fileName=${fileName}`, {
      headers:headers,
      responseType:'blob'
    });
  }

}
