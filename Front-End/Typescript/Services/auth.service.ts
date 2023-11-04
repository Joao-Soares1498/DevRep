import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http"
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl : string ="https://localhost:7007/api/User/";
  private userPayload:any;


  constructor(private http: HttpClient,private router:Router ) {
    //inserts user data in toke on this object
    this.userPayload = this.decodeToken();
  }

  //calls back end signup function
  signUp(userObject:any){
    return this.http.post<any>(`${this.baseUrl}register`,userObject)
  }
  //calls back end signup function
  login(loginObject:any){
    return this.http.post<any>(`${this.baseUrl}authenticate`,loginObject)
  }
  //clears token and routes to login
  LogOut(){
    localStorage.clear();
    //localStorage.clear();
    this.router.navigate(['login'])
  }
  //stores token in localstorage
  storeToken(tokenValue:string){
    localStorage.setItem('token',tokenValue)
  }

  //gets token
  getToken(){
    return localStorage.getItem('token')
  }

  //checks if user as token
  isLoggedIn():boolean{
    return !!localStorage.getItem('token')
  }

  //decodes token
  decodeToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    return jwtHelper.decodeToken(token);
  }

  //gets user name from the token
  getNameFromToken(){
    if(this.userPayload)
    return this.userPayload.unique_name;
  }

  //gets user role from the token
  getRoleFromToken(){
    if(this.userPayload)
    return this.userPayload.role;
  }

  //gets user name id from the token
  getIdFromToken(){
    if(this.userPayload)
    return this.userPayload.nameid;
  }
}
