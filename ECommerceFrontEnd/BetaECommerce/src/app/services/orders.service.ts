import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PlaceOrderRequest } from '../models/place-order-request';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  baseUrl="https://localhost:7027/api/Orders"

  constructor(private http:HttpClient) { }


  placeOrder(userId:PlaceOrderRequest):Observable<any>{
    return this.http.post<any>(`${this.baseUrl}/placeOrder`,userId);
  }
}
