import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/services/auth.service';
import { FolderService } from 'src/app/services/folder.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-my-eval',
  templateUrl: './my-eval.component.html',
  styleUrls: ['./my-eval.component.css']
})
export class MyEvalComponent implements OnInit{

  constructor(
    private fb:FormBuilder,
    private userStore: UserStoreService,
    private auth:AuthService,
    private folderService: FolderService,
    private toast:NgToastService,
    private router:Router){}

  public folders:any =[];
  public nameid:string="";
  myEvalForm!:FormGroup;

  ngOnInit(): void {
    //gets name id of the user
    this.userStore.getIdFromStore()
    .subscribe((val) => {
      const nameidFromToken = this.auth.getIdFromToken();
      this.nameid = val || nameidFromToken;
    });

    //loads folders
    this.loadFolders();


    this.myEvalForm = this.fb.group({
      nameid: [this.nameid, Validators.required],
    });
  }

  //calls the service to load the folders and files
  loadFolders(){

    this.folderService.getFolders(this.nameid)
    .subscribe(res=>{
      this.folders=res;
    })
  }

  //calls the service to download the file clicked
  downloadFile(folderName: string, fileName: string): void {
    this.folderService.downloadFile(this.nameid, folderName, fileName).subscribe(
      (response) => {
        const blob = new Blob([response], { type: 'application/octet-stream' });
        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        link.click();
      },
      (error) => {
        this.toast.error({
          detail: 'Erro',
          summary: error.message,
          duration: 5000
        });
      }
    );
  }

}
