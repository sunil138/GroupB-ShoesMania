import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(private http:HttpClient) { }

  PostSignup(signupObj:any):Observable<any>  
  {
    return this.http.post<any>("https://localhost:7196/api/Authentication/register",signupObj);    
  } 
}
