import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor(private userStore: UserStoreService,
     private auth: AuthService,
     private router:Router){}

  public unique_name :string="";

  ngOnInit(): void {

  //gets name of the user
    this.userStore.getNameFromStore()
    .subscribe(val=>{
      const unique_nameFromToken = this.auth.getNameFromToken();
      this.unique_name = val || unique_nameFromToken;
    });
  }
  //calls logout service
  logout(){
    this.auth.LogOut();
    localStorage.removeItem("EvId");
  }
  //routes to menu
  backToMenu(){
    this.router.navigate(['menu']);
    localStorage.removeItem("EvId");
  }

}
