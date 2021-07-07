import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { mapTo } from "rxjs/operators";
import { Product } from "../../models/product";


@Injectable({
  providedIn:"root"
})

export class ProductService {
  

  constructor(private http: HttpClient ) {
    
  }


  get headers(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json'
    });
  }

  host: string = "http://localhost/MeetupKafka";

  getList$: Observable<any> = this.http.get<any>(this.host + '/api/Product/GetList');

  public getList(): Observable<Product[]>{
    return this.http.get<Product[]>('/api/Product/GetList');
  }

  public newOrderProduct(product: Product): Observable<Product> {
    const formData = new FormData();
    for (const prop in product) {
      if (!product.hasOwnProperty(prop)) { continue; }
      formData.append(prop, product[prop]);
    }

    return this.http.post<Product>('/api/Product/NewOrder', formData).pipe();
  }

}
