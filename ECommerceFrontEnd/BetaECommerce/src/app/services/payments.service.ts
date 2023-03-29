import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {

  constructor(private http:HttpClient) { }

  addPayments(data:any):Observable<any>{
    return this.http.post<any>("https://localhost:7040/gateway/payment/addPayment",data);
  }
}
