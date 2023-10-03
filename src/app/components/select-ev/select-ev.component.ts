import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { EvsService } from 'src/app/services/evs.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-select-ev',
  templateUrl: './select-ev.component.html',
  styleUrls: ['./select-ev.component.css']
})
export class SelectEvComponent implements OnInit{

  constructor(
    private userStore:UserStoreService,
    private auth:AuthService,
    private evsService: EvsService,
    private router: Router,
  ){}

  public evs: any = [];
  public nameid: string = "";

  ngOnInit(): void {
      this.userStore.getIdFromStore()
      .subscribe((val) =>{
        const nameidFromToken = this.auth.getIdFromToken();
        this.nameid = val || nameidFromToken;
      });

    this.loadEvs();

  }

  loadEvs(){
    this.evsService.getEvs(this.nameid)
    .subscribe(res=>{
      this.evs=res;
    })
  }

  openEv(ev:any){
    localStorage.setItem("EvId",ev.id);
    this.router.navigate(['anualEval']);
  }
}
