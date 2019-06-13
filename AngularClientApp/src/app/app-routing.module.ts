import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { PricelistComponent } from 'src/app/pricelist/pricelist.component';
import { ShowPricesComponent } from 'src/app/show-prices/show-prices.component';
import { LinesComponent } from './lines/lines.component';
import { EditPricelistComponent } from './edit-pricelist/edit-pricelist.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: 'addpricelist', component: PricelistComponent},
  {path: 'pricelist', component: ShowPricesComponent},
  {path: 'lines', component: LinesComponent},
  {path: 'editpricelist', component: EditPricelistComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot((routes), {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
