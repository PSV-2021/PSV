import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrugstoreOfferComponent } from './drugstore-offer/drugstore-offer.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { TendersComponent } from './tenders/tenders.component';
import { TenderFinishingComponent } from './tender-finishing/tender-finishing.component';
import { NotificationsComponent } from './notifications/notifications.component';


const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'reviews', component: ReviewsComponent},
  { path: 'drugstore-offer', component: DrugstoreOfferComponent},
  { path: 'tenders', component: TendersComponent},
  { path: 'tender-finishing', component : TenderFinishingComponent},
  { path: 'notifications', component : NotificationsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
