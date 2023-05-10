import { Component, DoCheck, OnInit } from '@angular/core';
import { LoginService } from '../Servies/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit,DoCheck {

  constructor(private loginService :LoginService) { }
  
   emailId: any;
   loginStatus!:boolean;
  ngOnInit(): void {
   this.emailId = sessionStorage.getItem('AuthUser');

  }
  ngDoCheck(): void {
   if(this.loginService.loginStatus){
    this.emailId = sessionStorage.getItem('AuthUser');
    console.log(this.emailId);
    console.log(this.loginStatus);
   this.loginStatus =  this.loginService.loginStatus;
 console.log(this.loginStatus)
   }
  }
  logOut(){
    sessionStorage.clear();
    this.loginService.setLoginStatus(false);
  }

}
