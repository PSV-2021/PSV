import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivationAccountComponent } from './activation-account/activation-account.component';
import { CommentsObserveComponent } from './comments-observe/comments-observe.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';
import { RegistrationSuccessComponent } from './registration-success/registration-success.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReserveAppointmentStandardComponent } from './reserve-appointment-standard/reserve-appointment-standard.component';
import { RecommendAppointmentComponent } from './recommend-appointment/recommend-appointment.component';
import { SurveyComponent } from './survey/survey.component';
import { HomePageComponent } from './home-page/home-page.component';
import { AuthGuard } from './auth-guard';

const routes: Routes = [
  { path: 'home', component: HomePageComponent},
  { path: 'registration', component: RegistrationComponent},
  { path: 'appointment-standard', component: ReserveAppointmentStandardComponent, canActivate: [AuthGuard]},
  { path: 'survey/:id/:ap', component: SurveyComponent, canActivate: [AuthGuard]},
  { path: '', component: LandingComponent, pathMatch: 'full'},
  { path: 'comments', component: CommentsObserveComponent, pathMatch: 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'activate', redirectTo: "/login" },
  { path: 'user' ,  children: [{ path:'activate', component: ActivationAccountComponent }]},
  { path: 'medicalRecord', component: MedicalRecordComponent, canActivate: [AuthGuard]},
  { path: 'registrationSuccess', component: RegistrationSuccessComponent},
  { path: 'recommendAppointment', component: RecommendAppointmentComponent, canActivate: [AuthGuard]},
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
