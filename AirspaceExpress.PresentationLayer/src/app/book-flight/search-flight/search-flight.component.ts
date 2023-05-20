import { Component, OnInit } from '@angular/core';
import { BookFlightComponent } from '../book-flight.component';
import { BookFlightService } from 'src/app/Servies/book-flight.service';
import { FormArrayName, FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-search-flight',
  templateUrl: './search-flight.component.html',
  styleUrls: ['./search-flight.component.css']
})
export class SearchFlightComponent implements OnInit {

  constructor(private service :BookFlightService,private fb:FormBuilder) { }

  destination!:string[]; //This is where all the desintaions are stored 
  sources!:string[]; //This is where all the sources are stored
  travelClasses!:string[]; //This is where all the travel classes are stored.
  searchFlightForm!:FormGroup;//For to get the input form user to serach flight.
  showFlights! : boolean
  ngOnInit(): void {
    //These function are loaded as soon as page is loaded as they fetch
    // various details that are required in the form
    this.getAllDestination();
    this.getAllSources();
    this.getAllTravelClass();

    this.searchFlightForm= this.fb.group(
      {
        Flyingfrom:['',[Validators.required]],
        Flyingto:['',[Validators.required]],
        departingdate:['',[Validators.required]],
        travelClass :['',[Validators.required]],
        travellers:['',[Validators.required]],
        stops:['',[Validators.required]]
      }
    )
  }
  //Appending data from the service to destination string 
getAllDestination(){ 
  this.service.getAllDestination().subscribe({
    next :(data)=>{
     // console.log(data)
      this.destination =data;
      //console.log(this.destination)
  }})};
//Appending data from the serive to soruce string

  getAllSources(){
    this.service.getAllSources().subscribe({
      next:(data)=>{
        this.sources = data;
      }
    })
  }

  getAllTravelClass(){
    this.service.getAllTravelClasses().subscribe(
      {
        next:(data)=>{
          this.travelClasses = data;
        }
      }
    )
  }
  bookFlight(){
    console.log(this.searchFlightForm.value);
  }

}
