﻿import { Component } from "@angular/core";
import { DataService } from '../Shared/dataService';

@Component({
  selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: ['checkout.component.css']
})
export class Checkout {

  constructor(public data: DataService) {
  }

  onCheckout() {
    // TODO
    alert("Doing checkout");
  }
}