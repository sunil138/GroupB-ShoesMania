import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { CartComponent } from './components/cart/cart.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { OrdersComponent } from './components/orders/orders.component';
import { PaymentsComponent } from './components/payments/payments.component';
import { SignupComponent } from './components/signup/signup.component';
import { ViewComponent } from './components/view/view.component';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import { LoginGuard } from './guards/login.guard';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';

const routes: Routes = [
  {path:"",redirectTo:'home',pathMatch:'full'},
  {path:"home",component:HomeComponent},
  {path:"viewProduct/:id",component:ViewComponent},
  {path:"login",component:LoginComponent},
  {path:"signup",component:SignupComponent},
  {path:"admin",component:AdminComponent},
  {path:"cart",component:CartComponent},  
  {path:"orders",component:OrdersComponent},
  {path:"payment",component:PaymentsComponent},
  {path:'forgotpassword',component:ForgotpasswordComponent},  
  {path:'resetpassword',component:ResetpasswordComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule]
})
export class AppRoutingModule { }
