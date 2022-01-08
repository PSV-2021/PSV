import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrugstoreOfferComponent } from './drugstore-offer/drugstore-offer.component';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { PurchaseDrugsComponent } from './purchase-drugs/purchase-drugs.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewComponent } from './review/review.component';
import { DrugsConsumptionComponent } from './drugs-consumption-specs/drugs-consumption.component';
import { FilesComponent } from './files/files.component';
import { AllDrugstoresComponent } from './all-drugstores/all-drugstores.component';
import { DrugstoreComponent } from './drugstore/drugstore.component';
import { TenderComponent } from './tender/tender.component';
import { TenderOffersComponent } from './tender-offers/tender-offers.component';
import { HomePageComponent } from './home-page/home-page.component';
import { AuthGuard } from './auth-guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'home', component: HomePageComponent},
  { path: 'reviews', component: ReviewComponent, canActivate: [AuthGuard]},
  { path: 'feedbacks', component: FeedbacksComponent, canActivate: [AuthGuard]},
  { path: 'landingPage', component: LandingPageComponent},
  { path: 'login', component: LoginComponent},
  { path: 'purchase', component: PurchaseDrugsComponent},
  { path: 'files', component: FilesComponent},
  { path: 'drugstore-offer', component: DrugstoreOfferComponent},
  { path: 'drugs-consumption', component: DrugsConsumptionComponent},
  { path: 'all-drugstores', component: AllDrugstoresComponent},
  { path: 'drugstore/:id', component: DrugstoreComponent},
  { path: 'offer/:id', component: TenderOffersComponent},
  { path: 'tender', component: TenderComponent},
  { path: '', redirectTo: 'landingPage', pathMatch: 'full' },
  { path: '**', redirectTo: 'landingPage', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
