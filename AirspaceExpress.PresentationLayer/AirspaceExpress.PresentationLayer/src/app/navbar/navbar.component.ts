import { Component, OnInit, DoCheck } from '@angular/core';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, DoCheck {

  public emailId: any;
  constructor() { }
  //constructor(public ls: LoginService) { }

  ngOnInit(): void {
  }

  ngDoCheck() {
   // if (this.ls.loginStatus) this.emailId = JSON.parse(sessionStorage.getItem('AuthUser'))?.emailId;
  }

  logOut() {
    /* 
      reset loginStatus to false
      delete data from the session storage
      invoke this method on click of Logout Link of navbar
    */
  }

}
