import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import ValidateForm from 'src/app/helpers/validateForm';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  type: string = "password";
  loginForm!: FormGroup;

  constructor(private fb: FormBuilder,
     private auth : AuthService,
      private router : Router,
      private toast: NgToastService,
       private userStore: UserStoreService){}

  ngOnInit(): void {

    //login form structure
    this.loginForm = this.fb.group({
      id: ['',Validators.required],
      password: ['',Validators.required]
    })
  }


  onLogin(){
    //if form valid
    if(this.loginForm.valid){
      //calls service to login
      this.auth.login(this.loginForm.value).
      subscribe({
        next:(res=>{
          this.loginForm.reset();
          //alert(res.message);
          this.toast.success({detail:"SUCCESS",summary:res.message,duration:5000});
          this.auth.storeToken(res.token);
          const tokenPayload = this.auth.decodeToken();
          this.userStore.setNameFromStore(tokenPayload.unique_name);
          this.userStore.setRoleFromStore(tokenPayload.role);
          this.userStore.setIdFromStore(tokenPayload.nameid);
          localStorage.removeItem("EvId");
          this.router.navigate(['menu']);
        }),
        error:(err=>{
          this.toast.error({detail:"Error",summary:"something went wrong",duration:5000});
        })
      })

      console.log(this.loginForm.value);
    }else{

      console.log("Form invalid")
      //throw error
      ValidateForm.validateFields(this.loginForm);
    }
  }



}
