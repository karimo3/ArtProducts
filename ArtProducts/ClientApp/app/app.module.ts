import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";


import { AppComponent } from './app.component';
import { ProductList } from "./shop/productList.component";
import { DataService } from "../app/Shared/dataService";

@NgModule({
  declarations: [
      AppComponent,
      ProductList
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
  providers: [
      DataService
  ],
  bootstrap: [AppComponent] //decides which component to load up first
})
export class AppModule { }
