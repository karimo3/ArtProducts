import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) { }

    public products = [];

    loadProducts() {
        this.http.get("/api/products")
            .map((data: any[]) => {
                this.products = data;
                return true;
            });
    }

}