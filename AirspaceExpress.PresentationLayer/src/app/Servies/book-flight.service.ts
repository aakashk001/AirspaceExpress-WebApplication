import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookFlightService {

  constructor(private http:HttpClient) {

   }
//Function to get all the destination location from the database(Api)
   getAllDestination():Observable<any>{
    return this.http.get<any>(`https://localhost:44334/api/FlightBooking/GetAllDestination`)
    .pipe(tap(data=> console.log(data)),catchError(this.handleError))
   }
//function to get all the source location fromt the database(api)
   getAllSources():Observable<any>{
    return this.http.get<any>(`https://localhost:44334/api/FlightBooking/GetAllSources`)
    .pipe(tap(data=> console.log(data)),catchError(this.handleError))
    
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
