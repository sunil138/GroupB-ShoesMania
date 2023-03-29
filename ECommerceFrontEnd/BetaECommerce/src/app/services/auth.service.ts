import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  role:any;

  constructor(private http:HttpClient,private routes:Router) { }

  //sign in -- backend url for login
    signin(loginobj:any){
       return this.http.post<any>("https://localhost:7040/gateway/Authentication/login",loginobj);
    }

    forgotPassword(email:any):Observable<any>{
       return this.http.post<any>("https://localhost:7040/gateway/Authentication/forgotPassword",email);
    } 
   
    resetpassword(data:any):Observable<any>
      {
        return this.http.post<any>("https://localhost:7040/gateway/Authentication/resetPassword",data);
      } 
  
    
    //store the token
    storetoken(tokenvalue:string){
      localStorage.setItem('token',tokenvalue);
    }

    //store the userId
    storeUserId(userId: string, value: any){
      localStorage.setItem('userId',value);
      
    }

    //store the role
    storeRole(role:string){
      localStorage.setItem('role',role);
    }
    
  
    
    //get the token
    getToken(){
      return localStorage.getItem('token');
    }
    
    //getRole
    isRoleAdmin():boolean{
      this.role = localStorage.getItem('role');
      if(this.role == "Admin"){
        return true;
      }
      return false;
    }
  
    //getUserId
    getUserId(){
      return localStorage.getItem('userId');
    }
    
    //check whether the user is logged in sucess or not
    isloggedin():boolean{
        return !!localStorage.getItem('token');//true or false
    }
    
  
    
    signout(){
     localStorage.clear();
      this.routes.navigate(['home']);
    }
    
  
}
