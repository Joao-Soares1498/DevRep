import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{

  public role:string="";


  constructor(private router:Router,
    private auth: AuthService,
     private userStore: UserStoreService
     ){}

  ngOnInit(): void {

    //gets role to know filter access
    this.userStore.getRoleFromStore()
      .subscribe(val=>{
        const roleFromToken = this.auth.getRoleFromToken();
        this.role=val||roleFromToken;
    });

  }
  //routes to user evaluation component
  openMyEval(){
    this.router.navigate(['myEval']);
  }
  //routes to create evaluation component
  OpenNewEval(){
    this.router.navigate(['newEval']);
  }

  OpenSelectEv(){
    this.router.navigate(['selectEv']);
  }
}
