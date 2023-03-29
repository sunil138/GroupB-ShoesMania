import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedIn:boolean = false;

  constructor(public authService:AuthService,private route:Router) { }

  ngOnInit(): void {
    
   
  }

  signOut(){
    this.authService.signout();
    this.route.navigate(['home']);
  }

  
}
