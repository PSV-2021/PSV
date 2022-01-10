import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import {MatDatepickerModule} from '@angular/material/datepicker';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationComponent } from './navigation/navigation.component';
import { MaterialModule } from './material/material.module';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { DrugstoreOfferComponent } from './drugstore-offer/drugstore-offer.component';
import { TendersComponent } from './tenders/tenders.component';
import { TenderFinishingComponent } from './tender-finishing/tender-finishing.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    RegistrationComponent,
    ReviewsComponent,
    DrugstoreOfferComponent,
    TendersComponent,
    TenderFinishingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    MatDatepickerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
