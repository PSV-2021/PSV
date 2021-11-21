import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NavigationComponent } from './navigation/navigation.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { MatToolbarModule } from "@angular/material/toolbar";
import { MaterialModule } from './material/material.module';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewComponent } from './review/review.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { PurchaseDrugsComponent } from './purchase-drugs/purchase-drugs.component';
import { DrugstoreOfferComponent } from './drugstore-offer/drugstore-offer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    RegistrationComponent,
    ReviewComponent,
    LandingPageComponent,
    FeedbacksComponent,
    PurchaseDrugsComponent,
    DrugstoreOfferComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MaterialModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
