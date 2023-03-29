import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ForgotPassword } from 'src/app/models/ForgotPassword';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  // form: FormGroup;

  // constructor(private readonly fb: FormBuilder) {
  //   this.form = this.fb.group({
  //     username: ['', Validators.required],      
  //     password: ['', Validators.required]
  //   });
  //  }

  // ngOnInit(): void {
  // }

  // submitForm() {
  //   console.log(this.form.getRawValue());
  // }
  //Form Validables 

  loginObj:any={
    email:"",
    password:""

  }
  forgot:ForgotPassword=
  {
    email:''
  }

  email:string="";
registerForm:any = FormGroup;
submitted = false;
constructor( private formBuilder: FormBuilder,private authService:AuthService,private route:Router){}
//Add user form actions
get f() { return this.registerForm.controls; }
onSubmit() {
  
  this.submitted = true;
  // stop here if form is invalid
  if (this.registerForm.invalid) {
      return;
  }
  //True if all the fields are filled
  // if(this.submitted)
  // {
  //   alert("Great!!");
  // }

  this.authService.signin(this.registerForm.value).subscribe((resp)=>{
    console.log(resp);
    this.authService.storetoken(resp.accessToken);
    this.authService.storeRole(resp.role);
    this.authService.storeUserId("userId",resp.userId);
    console.log(this.authService.getUserId());
    
    if(resp.role == "User"){
      this.route.navigate(['home']);
    }else if(resp.role == "Admin"){
      this.route.navigate(['admin']);
    }else{
      this.route.navigate(['login']);
      alert("User not found");
    }
    
  });
  console.log(this.registerForm.value);

 
}
  ngOnInit() {
    //Add User form validations
    this.registerForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
    });
  }

  // forgotPassword(){
  //   this.authService.forgotPassword(this.forgot).subscribe(res=>{
  //     console.log('res',res); 
  //   }); 
  //   this.route.navigate(['resetpassword']);   
  // }

}
