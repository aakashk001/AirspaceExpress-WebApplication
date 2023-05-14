import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { BookFlightComponent } from './book-flight/book-flight.component';
import { ManageBookingComponent } from './manage-booking/manage-booking.component';
import { SearchFlightComponent } from './book-flight/search-flight/search-flight.component';

const routes: Routes = [
  {path: '',redirectTo :'home',pathMatch:'full'},
  {path :'home',component:HomeComponent},
  {path:'login',component:LoginComponent},
  {path:'bookFlight',component:BookFlightComponent,children : [
    {path:'',component:SearchFlightComponent},
    {path:'searchFlight',component:SearchFlightComponent}
  ]},
  {path:'manageFlight',component:ManageBookingComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
