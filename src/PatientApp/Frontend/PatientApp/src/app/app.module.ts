import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NavigationComponent } from './navigation/navigation.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule} from '@angular/common/http';
import { MatTableModule } from "@angular/material/table";
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { AppComponent } from './app.component';
import { MatToolbarModule } from "@angular/material/toolbar";
import { LandingComponent } from './landing/landing.component';
import { CommentsObserveComponent } from './comments-observe/comments-observe.component';
import { RegistrationComponent } from './registration/registration.component';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatRadioModule } from '@angular/material/radio';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDatepickerModule } from '@angular/material/datepicker'
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { SurveyComponent } from './survey/survey.component';
import { ActivationAccountComponent } from './activation-account/activation-account.component';
import { LoginComponent } from './login/login.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';
import { RegistrationSuccessComponent } from './registration-success/registration-success.component';
import { ReserveAppointmentStandardComponent } from './reserve-appointment-standard/reserve-appointment-standard.component';
import { MatStepperModule } from '@angular/material/stepper';
import { AppointmentsObserveComponent } from './appointments-observe/appointments-observe.component';
import { RecommendAppointmentComponent } from './recommend-appointment/recommend-appointment.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    LandingComponent,
    CommentsObserveComponent,
    RegistrationComponent,
    SurveyComponent,
    ActivationAccountComponent,
    LoginComponent,
    MedicalRecordComponent,
    RegistrationSuccessComponent,
    ReserveAppointmentStandardComponent,
    AppointmentsObserveComponent,
    RecommendAppointmentComponent


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    HttpClientModule,
    MatTableModule,
    MatCardModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatIconModule,
    MatGridListModule,
    MatButtonToggleModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,
    MatRadioModule,
    MatSnackBarModule,
    FormsModule,
    MatStepperModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
