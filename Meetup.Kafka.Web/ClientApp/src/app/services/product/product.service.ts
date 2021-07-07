import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, OnInit } from "@angular/core";
import { Observable } from "rxjs";
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


  getList$: Observable<any> = this.http.get<any>('/api/Product/GetList');

  public getList(): Observable<Product[]>{
    return this.http.get<Product[]>('/api/Product/GetList');
  }

  public newOrderProduct(product: Product): Observable<Product> {
    return this.http.post<any>('/api/Product/NewOrder', JSON.stringify(product), { headers: this.headers });
  }

}
