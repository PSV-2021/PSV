import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrugstoreOfferComponent } from './drugstore-offer/drugstore-offer.component';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { PurchaseDrugsComponent } from './purchase-drugs/purchase-drugs.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewComponent } from './review/review.component';
import { DrugsConsumptionComponent } from './drugs-consumption-specs/drugs-consumption.component';
import { AllDrugstoresComponent } from './all-drugstores/all-drugstores.component';
import { DrugstoreComponent } from './drugstore/drugstore.component';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'reviews', component: ReviewComponent},
  { path: 'feedbacks', component: FeedbacksComponent},
  { path: 'landingPage', component: LandingPageComponent},
  { path: 'purchase', component: PurchaseDrugsComponent},
  { path: 'drugstore-offer', component: DrugstoreOfferComponent},
  { path: 'drugs-consumption', component: DrugsConsumptionComponent},
  { path: 'all-drugstores', component: AllDrugstoresComponent},
  { path: 'drugstore/:id', component: DrugstoreComponent},
  { path: '', redirectTo: 'landingPage', pathMatch: 'full' },
  { path: '**', redirectTo: 'landingPage', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
