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
import { SurveyComponent } from './survey/survey.component';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'survey', component: SurveyComponent },
  { path: 'appointment-standard', component: ReserveAppointmentStandardComponent},
  { path: '', component: LandingComponent, pathMatch: 'full'},
  { path: 'comments', component: CommentsObserveComponent, pathMatch: 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'activate', redirectTo: "/login" },
  { path: 'user' ,  children: [{ path:'activate', component: ActivationAccountComponent }]},
  { path: 'medicalRecord', component: MedicalRecordComponent },
  { path: 'registrationSuccess', component: RegistrationSuccessComponent},
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
