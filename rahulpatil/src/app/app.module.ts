import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HealthcheckComponent } from './modules/healthcheck/pages/healthcheck.component';
import { MainComponent } from './common/main/main.component';
import { HttpClientModule } from '@angular/common/http';
import { CitiesComponent } from './modules/worldcities/pages/cities/cities.component';
import { NavMenuComponent } from './modules/common/nav-menu/nav-menu.component';
import { HomeComponent } from './modules/common/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './shared/modules/angular-material.module';


@NgModule({
  declarations: [
    AppComponent,
    HealthcheckComponent,
    MainComponent,
    CitiesComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AngularMaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
