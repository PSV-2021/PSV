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
import { DrugsConsumptionComponent } from './drugs-consumption-specs/drugs-consumption.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FilesComponent } from './files/files.component';
import { MatBadgeModule } from '@angular/material/badge';
import { ToastrModule } from 'ngx-toastr';
import { timeout } from 'rxjs/operators';
import { AllDrugstoresComponent } from './all-drugstores/all-drugstores.component';
import { DrugstoreComponent } from './drugstore/drugstore.component';
import { TenderComponent } from './tender/tender.component';
import { TenderOffersComponent } from './tender-offers/tender-offers.component';
import { HomePageComponent } from './home-page/home-page.component';

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
    DrugsConsumptionComponent,
    FilesComponent,
    AllDrugstoresComponent,
    DrugstoreComponent,
    TenderComponent,
    TenderOffersComponent,
    HomePageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatBadgeModule,
    ToastrModule.forRoot({
      preventDuplicates: false,
      timeOut: 4000,
      positionClass: 'toast-top-right',
    })
  ],
  providers: [],
  bootstrap: [AppComponent,]
})
export class AppModule { }
