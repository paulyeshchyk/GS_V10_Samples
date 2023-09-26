import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { ContractorDetailsComponent } from './contractor-details/contractor-details.component';
import { ContractorDetailFormComponent } from './contractor-details/contractor-detail-form/contractor-detail-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ContractorDetailsComponent,
    ContractorDetailFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
