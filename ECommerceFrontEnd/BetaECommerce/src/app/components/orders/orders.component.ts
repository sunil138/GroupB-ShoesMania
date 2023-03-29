import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { OrederResponse } from 'src/app/models/oreder-response';
import { Payments } from 'src/app/models/payments';
import { PlaceOrderRequest } from 'src/app/models/place-order-request';
import { AuthService } from 'src/app/services/auth.service';
import { OrdersService } from 'src/app/services/orders.service';
import { PaymentsService } from 'src/app/services/payments.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  placeOrder:PlaceOrderRequest={
    userId:0
  }

  orderResponse:OrederResponse={
    OrderId:0,
    OrderDate:new Date(),
    TotalAmount:0
  }

  title = 'Payment';
  paymentForm!:FormGroup;
  pay:Payments= 
  {
      
    
    id:'',
    UserName:'',
    PaymentType:'',
    OrderId:0, 
    Amount:0,
    DeliveryAddress:'',
    UserId:0
    
  }

  constructor(private orderService:OrdersService,private authService:AuthService,private paymentsService:PaymentsService,private formBuilder: FormBuilder,private route:Router) { }

  ngOnInit(): void {
    this.placeOrder.userId=Number(this.authService.getUserId());
    this.order();
  }

  order(){
    this.orderService.placeOrder(this.placeOrder).subscribe((resp)=>{
      console.log(resp);
      this.orderResponse.OrderId = resp.orderId;
      this.orderResponse.TotalAmount=resp.totalAmount;
    });
  }

  addPayment(){

    this.paymentsService.addPayments(this.pay).subscribe((resp)=>{
      this.route.navigate(["payment"]);
    });
    
    
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





}
