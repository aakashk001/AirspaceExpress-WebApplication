import { Component, OnInit } from '@angular/core';
import { BookFlightComponent } from '../book-flight.component';
import { BookFlightService } from 'src/app/Servies/book-flight.service';
import { FormArrayName, FormBuilder, FormGroup, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-flight',
  templateUrl: './search-flight.component.html',
  styleUrls: ['./search-flight.component.css']
})
export class SearchFlightComponent implements OnInit {

  constructor(private service :BookFlightService,private fb:FormBuilder) { }

  destination!:string[];
  sources!:string[];
  travelClasses!:string[];
  bookingForm!:FormGroup;
  ngOnInit(): void {
    this.getAllDestination();
    this.getAllSources();
    this.getAllTravelClass();

    this.bookingForm = this.fb.group(
      {
        Flyingfrom:[''],
        Flyingto:[''],
        departingdate:[''],
        travelClass :['']
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
    console.log(this.bookingForm.value);
  }

}
