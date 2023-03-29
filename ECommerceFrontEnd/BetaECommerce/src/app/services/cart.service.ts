import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductToCartRequest } from '../models/product-to-cart-request';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseUrl="https://localhost:7045/api/Cart";

  constructor(private http:HttpClient) { }

  addToCart(id:number,productId:ProductToCartRequest):Observable<any>{
    return this.http.post<any>(`${this.baseUrl}/${id}`,productId);
  }

  

  getCartByUserId(id:number):Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getCartByUserId/${id}`);
  }

  deleteFromCartItem(id:number):Observable<any>{
    return this.http.delete<any>(`${this.baseUrl}/deleteCartItem/${id}`);
  }
}
