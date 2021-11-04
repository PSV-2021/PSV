import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
<<<<<<< HEAD
import { NavigationComponent } from './navigation/navigation.component';
=======
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';

>>>>>>> e28da3b478b9b0a8a8a9c221976111a9939c0361
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
<<<<<<< HEAD
import { MatToolbarModule } from "@angular/material/toolbar";
=======
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationComponent } from './navigation/navigation.component';
import { MaterialModule } from './material/material.module';
import { RegistrationComponent } from './registration/registration.component';
import { ReviewComponent } from './review/review.component';
>>>>>>> e28da3b478b9b0a8a8a9c221976111a9939c0361

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    NavigationComponent
=======
    NavigationComponent,
    RegistrationComponent,
    ReviewComponent,
>>>>>>> e28da3b478b9b0a8a8a9c221976111a9939c0361
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
<<<<<<< HEAD
    MatToolbarModule,
=======
    MaterialModule,
    FormsModule,
>>>>>>> e28da3b478b9b0a8a8a9c221976111a9939c0361
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
