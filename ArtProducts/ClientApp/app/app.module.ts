import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from "@angular/http";


import { AppComponent } from './app.component';
import { ProductList } from "./shop/productList.component";
import { Cart } from "./shop/cart.component";
import { Shop } from "./shop/shop.component";
import { Checkout } from "./checkout/checkout.component";
import { Login } from "./login/login.component";
import { DataService } from "../app/Shared/dataService";

import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";

let routes = [
    { path: "", component: Shop },
    { path: "checkout", component: Checkout },
    {path: "login", component: Login }
];

@NgModule({
  declarations: [
      AppComponent,
      ProductList,
      Cart, 
      Shop,
      Checkout,
      Login
  ],
  imports: [
      BrowserModule, //tells it how to host it on web page 
      HttpModule,
      FormsModule,
      RouterModule.forRoot(routes, {
          useHash: true, //for SPA
          enableTracing: false //for Debugging of the routes
      })
  ],
  providers: [
      DataService
  ],
  bootstrap: [AppComponent] //decides which component to load up first
})
export class AppModule { }
