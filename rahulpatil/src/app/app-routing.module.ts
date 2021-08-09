import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './modules/common/home/home.component';
import { HealthcheckComponent } from './modules/healthcheck/pages/healthcheck.component';
import { CitiesComponent } from './modules/worldcities/pages/cities/cities.component';
import { CountriesComponent } from './modules/worldcities/pages/countries/countries.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'healthcheck', component: HealthcheckComponent},
  { path: 'cities', component: CitiesComponent },
  { path: 'countries', component: CountriesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
