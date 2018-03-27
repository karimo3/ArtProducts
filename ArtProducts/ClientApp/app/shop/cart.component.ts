import { Component } from "@angular/core";
import { DataService } from "../Shared/dataService";
import { Router } from "@angular/router";

@Component({
    selector: "the-cart",
    templateUrl: "cart.component.html",
    styleUrls: []
})

export class Cart {
    constructor(private data: DataService, private router: Router) { }

    OnCheckout() {
        if (this.data.loginRequired) {
            //Force Login
            this.router.navigate(["login"]);
        } else {
            //Go to Checkout
            this.router.navigate(["checkout"]);
        }
    }
}