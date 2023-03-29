import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {
  // canActivate(
  //   route: ActivatedRouteSnapshot,
  //   state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
  //   return true;
  // }
  constructor(private routes:Router,private auth:AuthService){} 
  canActivate():boolean
   {
    if(this.auth.isloggedin()) 
    {
      return true; 
    }
    else
    {
      alert("Please Login"); 
      this.routes.navigate(['login'])
      return false;  
    }
  } 
}
