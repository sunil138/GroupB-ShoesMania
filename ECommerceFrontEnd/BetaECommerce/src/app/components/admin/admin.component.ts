import { Component, OnInit } from '@angular/core';
import { Products } from 'src/app/models/products';
import { Users } from 'src/app/models/users';
import { AdminService } from 'src/app/services/admin.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  userList:any=[];
 updatedataone:any;

currentData:Users=
  {
    userId:0,
    userName:'',
    email:'',
    role:'',
    city:'',
    address:''  
  }

  productList:any=[]; 
  updatedata:any;
  pro:Products={
    productId: 0,
    name: '',
    description: '', 
    price:0,
    
    category:{
      categoryId:0,
      category:'',
      subCategory:''
    }
 
  }
  currentdata:Products={
    productId: 0,
    name: '',
    description: '',
    price:0,
   
    category:{
      categoryId:0,
      category:'',
      subCategory:''
    }
}

delUser:any;

  constructor(private adminService:AdminService,private productService:ProductService) { }

  ngOnInit(): void {
    this.GetUsers(); 
    this.GetProducts();
  }

  
 GetUsers()
  {
    this.adminService.GetUser().subscribe(response=>{
      this.userList=response; 
      console.log(response); 
    })
  }

  GetUserbyid(data:Users)
  {
    this.adminService.GetUserById(data.userId).subscribe(response=>{
      this.updatedataone=response;
      this.currentData=this.updatedataone; 
    })
  }

  Updateuser()
  {
    this.adminService.UpdateUser(this.currentData).subscribe(response=>{
      this.GetUsers();
      console.log(response); 
    })
  }

  deleteUser(currentUser:any){
    this.currentData=currentUser;
  }
  DeleteUserById(id:any)
  {
    this.adminService.DeleteUser(id).subscribe(response=>{
      this.GetUsers();
      console.log(response); 
    })
  }

  GetProducts(){
    this.productService.getAllProducts().subscribe(response=>{
      this.productList=response;
      console.log(response);
  });
  }
  GetProductsById(data:Products){
    this.productService.getProductById(data.productId).subscribe(response=>{
      this.updatedata=response;
      this.currentdata=this.updatedata;
      console.log(response);
    });
  }
  AddProducts(){
    this.productService.addNewProduct(this.pro).subscribe(response=>{
      this.GetProducts();
      console.log(response);  
    });
  }
  DeleteProducts(productId:any){
    this.productService.deleteProductById(productId).subscribe(response=>{ 
      this.GetProducts();
    });

  }
  UpdateProducts(){
    this.productService.updateProduct(this.currentdata).subscribe(response=>{
      this.GetProducts();
      console.log(response);

    })
  }



  

}
