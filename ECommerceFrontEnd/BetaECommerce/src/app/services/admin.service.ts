import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from '../models/users';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  GetUser():Observable<any>
    {
      return this.http.get<any>("https://localhost:7040/gateway/user"); 
    }

    GetUserById(id:any):Observable<any>
    {
      return this.http.get<any>("https://localhost:7040/gateway/user"+"/"+id); 
    }
    UpdateUser(data:Users):Observable<any>
    {
      return this.http.put<any>("https://localhost:7040/gateway/user/updateUser",data); 
    }
    DeleteUser(id:any):Observable<any>
    {
      return this.http.delete<any>("https://localhost:7040/gateway/user/deleteUser"+"/"+id); 
    }

}
