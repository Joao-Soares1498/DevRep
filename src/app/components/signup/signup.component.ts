import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/validateForm';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{

  type: string = "password";
  signupForm!: FormGroup;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router){}

  ngOnInit(): void {

    //signup form structure
      this.signupForm = this.fb.group({
        id: ['',Validators.required],
        email: ['',Validators.required],
        name: ['',Validators.required],
        password: ['',Validators.required]
      })
  }

  //signup
  onSignUp(){
    //if the form is valid
    if(this.signupForm.valid){
      //calls the service to sing up new user
      this.auth.signUp(this.signupForm.value)
      .subscribe({
        next:(res=>{
          alert(res.message)
          this.signupForm.reset();
          this.router.navigate(['login']);
        }),
        error:(err=>{
          alert(err.error.message)
        })
      })
    }else{
      console.log("Form invalid");
      ValidateForm.validateFields(this.signupForm);
    }
  }

}
