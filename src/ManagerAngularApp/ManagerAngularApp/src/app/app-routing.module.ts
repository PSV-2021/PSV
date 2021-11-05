import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewComponent } from './review/review.component';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'reviews', component: ReviewComponent},
  { path: 'feedbacks', component: FeedbacksComponent},
  { path: 'landingPage', component: LandingPageComponent},
  { path: '', redirectTo: 'landingPage', pathMatch: 'full' },
  { path: '**', redirectTo: 'landingPage', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
