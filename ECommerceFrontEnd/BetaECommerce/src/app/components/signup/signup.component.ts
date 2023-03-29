import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from 'src/app/models/register';
import { SignupService } from 'src/app/services/signup.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  // constructor(private fb: FormBuilder) { }
  // profileForm: FormGroup = new FormGroup({
  //   userName: new FormControl(''),
  //   email:new FormControl(''),
  //   password:new FormControl(''),
  //   confirmPassword:new FormControl(''),
  //   city:new FormControl(''),
  //   address:new FormControl('')
    
  // });
  // submitted = false;
  // ngOnInit(): void {
  //   this.profileForm = this.fb.group(
  //     {
  //       userName: ['', Validators.required,Validators.minLength(4)],
  //       email:['',Validators.required,Validators.email],
  //       password:['',Validators.required, Validators.minLength(6)],
  //       confirmPassword:['',Validators.required],
  //       city:['',Validators.required],
  //       address:['',Validators.required]
  //     });
  //   }
  //   get f() { return this.profileForm.controls; }
  // onSubmit() {
  //   // TODO: Use EventEmitter with form value
  //   this.submitted = true;
  //   if (this.profileForm.invalid) {
  //     return;
  //   }
  //   console.warn(this.profileForm.value);
  // }

  signup:any = {};

  signupObj:Register=  
  {
    userName:'',
    email:'',
    password:'',
    confirmPassword:'',
    city:'',
    address:'',
  }

  registerForm!:FormGroup; 
  constructor( private fb:FormBuilder, private service:SignupService,private routes:Router){} 
  ngOnInit()
  {
    this.registerForm=this.fb.group({
      userName:['',Validators.required], 
      email:['',Validators.required],
      password:['',Validators.required],
      confirmPassword:['',Validators.required],
      city:['',Validators.required],
      address:['',Validators.required],  
    })
  }
  AddSignUp()  
  {
    if(this.registerForm.valid)
    {
    this.service.PostSignup(this.signupObj).subscribe(res=>{
      console.log('res',res);  
       this.routes.navigate(['login']); 
       alert("Registration Success");   
    })
    }
    else 
    {
      this.validateAllFormFields(this.registerForm);
      alert("Registration Failed");    
    }
  } 

  private validateAllFormFields(formGroup:FormGroup)
  {
    Object.keys(formGroup.controls).forEach(field=>{
      const control=formGroup.get(field); 
      if(control instanceof FormControl)
      {
        control.markAsDirty({onlySelf:true});
      }
      else if(control instanceof FormGroup)
      {
        this.validateAllFormFields(control); 
      }
    })
  }

  emailValidator(control: FormControl): ValidationErrors {
  const email = control.value;
  if (email && !email.endsWith('.com') && !email.endsWith('.in') && !email.endsWith('.net')) {
    return { invalidEmail: true };
  }
  return email;
  }


  // customEmailValidator(control: { value: string; }) {
  //   const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|in|net)$/;
  //   if (control.value && !emailPattern.test(control.value)) {
  //     return { invalidEmail: true };
  //   }
  //   return null;
  // }
  
}
