import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductToCartRequest } from 'src/app/models/product-to-cart-request';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  product:any;
  userId:number=0;
  productToCart:ProductToCartRequest={
    productId:0,
    quantity:1

  };

  constructor(private productService:ProductService,private route:ActivatedRoute,private cartService:CartService,public authService:AuthService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params=>this.getProductById(params['id']));
  }



  getProductById(id:number){
    this.productService.getProductById(id).subscribe((resp)=>{
      this.product=resp;
    },(error:HttpErrorResponse)=>{
      console.error(error);
    });
  }

  getCurrentUserId(){
    console.log(this.authService.getUserId());
    console.log( this.product.productId);
  }

  addToCart(){
    this.userId =Number(this.authService.getUserId());
    this.productToCart.productId=this.product.productId;
    this.cartService.addToCart(this.userId,this.productToCart).subscribe((resp)=>{
      console.log(resp);
      alert("Product added to cart succesfully.");
    });
    

  }
}
