import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrugstoreOfferComponent } from './drugstore-offer/drugstore-offer.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { TendersComponent } from './tenders/tenders.component';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'reviews', component: ReviewsComponent},
  { path: 'drugstore-offer', component: DrugstoreOfferComponent},
  { path: 'tenders', component: TendersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
