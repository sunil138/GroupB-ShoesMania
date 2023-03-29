import { Component, OnInit } from '@angular/core';
import { PlaceOrderRequest } from 'src/app/models/place-order-request';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  userId:number=0;
  cartItems:any;
  placeOrder:PlaceOrderRequest={
    userId:0
  }

  constructor(private cartService:CartService,private authService:AuthService,private orderService:OrdersService) { }

  ngOnInit(): void {
    this.userId =Number(this.authService.getUserId());
    this.placeOrder.userId=Number(this.authService.getUserId());
    this.getCartByUserId();
  }

  getCartByUserId(){
    this.userId =Number(this.authService.getUserId());
    this.cartService.getCartByUserId(this.userId).subscribe((resp)=>{
      this.cartItems=resp.cartItems;
    });

    
  }

  order(){
    this.orderService.placeOrder(this.placeOrder).subscribe((resp)=>{
      console.log(resp);
    });
  }

  deleteCartItem(id:number){
    this.cartService.deleteFromCartItem(id).subscribe((resp)=>{
      console.log(resp);
      window.location.reload();
    });
  }


}
