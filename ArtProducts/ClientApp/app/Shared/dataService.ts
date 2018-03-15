import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) { }

    public products = [];

    loadProducts() {
         this.http.get("/api/products") //needed to add the "return" keyword in order for the "subscribe" method to work... not the same as video
            .map((data: any[]) => {
                this.products = data;
                return true;
            });
    }

}