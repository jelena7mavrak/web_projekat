import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpService } from 'src/app/service/http.service';
import { LoginServiceService } from './service/login-service.service';
import { RegistrationComponent } from './registration/registration.component';
import { RegistrationService } from 'src/app/service/registration.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule, 
    FormsModule
  ],
  providers: [HttpService, LoginServiceService,  RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
