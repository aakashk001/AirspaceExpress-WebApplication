import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder,Validators} from '@angular/forms'
import { LoginService } from '../Servies/login.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm! : FormGroup;
  errorMessage! : String;



  constructor(private fb :FormBuilder,private loginService:LoginService,private route :Router) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group(

      {
        username :['',[Validators.required,Validators.pattern("^[A-z]+[0-9]+@+[a-z]+.com$")]],
        password: ['',[Validators.required,Validators.minLength(2),Validators.maxLength(15)]]
      }
    )
  }

  login(form:FormGroup){
    console.log(this.loginForm.value);
    this.loginService.validateUser(form.value.username,form.value.password).subscribe(
      {
        next : (data) =>{
          if(data == "Successfull Login"){
            console.log(data);
           sessionStorage.setItem('AuthUser',form.value.username);
           sessionStorage.setItem("loginStatus",`true`)
           this.loginService.setLoginStatus(true);
           this.route.navigate(['/bookFlight']);
          }
          else {
            this.errorMessage = data;
            sessionStorage.clear();
            sessionStorage.setItem("loginStatus",`false`);
            this.loginService.setLoginStatus(false);
          }
        }
      }
    )


  }

}
