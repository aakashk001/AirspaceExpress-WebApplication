import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchFlightComponent } from './search-flight/search-flight.component';
/* import the necessary modules here */ 

/* Add the required route to load corresponding component */ 
const routes: Routes = [
  {path :'',component:SearchFlightComponent}
//{path: 'searchflight',component:SearchFlightComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)], //This is used when we want to sperate some rotuing module from mail roting module some thing like group the routing module  
  exports: [RouterModule]
})
export class FlightBookingRoutingModule { }
