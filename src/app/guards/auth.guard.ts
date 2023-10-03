import { CanActivate, Router,} from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn:'root'
})

export class AuthGuard implements CanActivate {

  constructor(private auth : AuthService,private router:Router){}

  //checks if user is logged in to access defined routes
  canActivate(): boolean  {
    if(this.auth.isLoggedIn()){
      return true;
    }else{
      alert("Please Login First");
      this.router.navigate(['login'])
      return false;
    }
  }

};
