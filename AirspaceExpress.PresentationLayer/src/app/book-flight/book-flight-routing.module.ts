import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
/* import the necessary modules here */ 

/* Add the required route to load corresponding component */ 
const routes: Routes = [
    
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FlightBookingRoutingModule { }
