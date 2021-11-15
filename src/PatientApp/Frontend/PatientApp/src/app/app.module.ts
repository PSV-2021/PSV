import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NavigationComponent } from './navigation/navigation.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule} from '@angular/common/http';
import { MatTableModule } from "@angular/material/table";
import {MatCardModule} from '@angular/material/card';
import { MatRadioModule } from '@angular/material/radio';

import { AppComponent } from './app.component';
import { MatToolbarModule } from "@angular/material/toolbar";
import { LandingComponent } from './landing/landing.component';
import { CommentsObserveComponent } from './comments-observe/comments-observe.component';
import { SurveyComponent } from './survey/survey.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    LandingComponent,
    CommentsObserveComponent,
    SurveyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    HttpClientModule,
    MatTableModule,
    MatCardModule,
    MatRadioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
