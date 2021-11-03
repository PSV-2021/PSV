import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewsComponent } from './reviews/reviews.component';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'reviews', component: ReviewsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
