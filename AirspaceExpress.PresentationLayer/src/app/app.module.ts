import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { BookFlightComponent } from './book-flight/book-flight.component';
import { ManageBookingComponent } from './manage-booking/manage-booking.component';
import { PageNotFindComponent } from './page-not-find/page-not-find.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeCarouselComponent } from './home-carousel/home-carousel.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FlightListComponent } from './book-flight/flight-list/flight-list.component';
import { PassengerDetailsComponent } from './book-flight/passenger-details/passenger-details.component';
import { SearchFlightComponent } from './book-flight/search-flight/search-flight.component';
import { ButtonDirective } from './shared/button.directive';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    BookFlightComponent,
    ManageBookingComponent,
    PageNotFindComponent,
    NavbarComponent,
    HomeCarouselComponent,
    FlightListComponent,
    PassengerDetailsComponent,
    SearchFlightComponent,
    ButtonDirective
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
