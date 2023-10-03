import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserStoreService {
  private unique_name$ = new BehaviorSubject<string>('');
  private role$ = new BehaviorSubject<string>('');
  private nameid$ = new BehaviorSubject<string>('');

  constructor() {}

  //gets role from local storage
  public getRoleFromStore() {
    return this.role$.asObservable();
  }
  //sets role from local storage
  public setRoleFromStore(role: string) {
    this.role$.next(role);
  }
  //gets name from local storage
  public getNameFromStore() {
    return this.unique_name$.asObservable();
  }
  //sets name from local storage
  public setNameFromStore(unique_name: string) {
    this.unique_name$.next(unique_name);
  }
  //gets id from local storage
  public getIdFromStore(){
    return this.nameid$.asObservable();
  }
  //sets id from local storage
  public setIdFromStore(nameid:string){
    this.nameid$.next(nameid);
  }
}
