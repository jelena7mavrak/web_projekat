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
import { NavbarComponent } from './navbar/navbar.component';
import { PricelistComponent } from './pricelist/pricelist.component';
import { ShowPricesComponent } from './show-prices/show-prices.component';
import { PricelistSService } from 'src/app/service/pricelist-s.service';
import { LinesComponent } from './lines/lines.component';
import { LineSService } from 'src/app/service/line-s.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    NavbarComponent,
    PricelistComponent,
    ShowPricesComponent,
    LinesComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule, 
    FormsModule
  ],
  providers: [HttpService, LoginServiceService,  RegistrationService, PricelistSService, LineSService],
  bootstrap: [AppComponent]
})
export class AppModule { }
