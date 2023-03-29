import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Products } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl = "https://localhost:7040/gateway/product";

  constructor(private http:HttpClient) { }

  getAllProducts():Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getAllProducts`);
  }

  getProductById(id:number):Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getProductById/${id}`); 
  }

  addNewProduct(data:any):Observable<any>{
    return this.http.post<any>(`${this.baseUrl}/addNewProduct`,data);   
  }


  deleteProductById(productId:any):Observable<any>{
    return this.http.delete<any>(`${this.baseUrl}/deleteProduct/${productId}`);
  }


  updateProduct(data:Products):Observable<any>{
    return this.http.put<any>(`${this.baseUrl}/updateProduct`,data);
  }
}
