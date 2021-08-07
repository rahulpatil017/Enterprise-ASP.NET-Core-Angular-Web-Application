import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HealthcheckComponent } from './modules/healthcheck/healthcheck.component';

const routes: Routes = [
  { path: '', component: HealthcheckComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
