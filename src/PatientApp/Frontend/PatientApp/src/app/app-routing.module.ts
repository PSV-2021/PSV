import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { SurveyComponent } from './survey/survey.component';

const routes: Routes = [
  { 
    path: 'survey', 
    component: SurveyComponent
  },
  { 
    path: '', 
    component: LandingComponent,
    pathMatch: 'full'
  },
  { 
    path: '**', 
    redirectTo: ''
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
