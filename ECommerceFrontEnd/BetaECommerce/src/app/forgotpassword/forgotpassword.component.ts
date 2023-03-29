import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ForgotPassword } from '../models/ForgotPassword';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {

  forgot:ForgotPassword=
  {
    email:''
  }
 
  ForgotPassword(){
    this.authService.forgotPassword(this.forgot).subscribe(res=>{
      console.log('res',res); 
    }); 
    this.route.navigate(['resetpassword']);    
  }
  constructor(private route:Router,private authService:AuthService) { } 

  ngOnInit()
  {
    
  }
}
