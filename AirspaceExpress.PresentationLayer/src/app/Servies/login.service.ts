import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHandler, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginStatus  = false;
  constructor(private http:HttpClient) {
      
   }
   setLoginStatus(status:boolean){
    this.loginStatus = status;
   }

   validateUser(emailId:any,password:any ):Observable<any>{
    let httparms2 = new HttpParams().set('emailId',emailId).set('password',password)
    return this.http.get<any>(`https://localhost:44334/api/Home/AuthenticateUser`,{params:httparms2},)
    .pipe(tap(data=>console.log(data)),catchError(this.handleError)) 
   }

   private handleError(err:HttpErrorResponse):Observable<any>{
    let errMsg= '';
    if(err.error instanceof Error){
      console.log('An error occured', err.error.message);
      errMsg = err.error.message;
    }
    else{
      console.log(`Backend returened code ${err.status}`);
      errMsg = err.error.status;
    }
    return throwError(()=>errMsg);
  }
}

