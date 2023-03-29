import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent implements OnInit {

  paymentTypes = ['Credit Card', 'Debit Card', 'PayPal'];

 

  constructor(private fb: FormBuilder) {
  
  }

  ngOnInit(): void {
      
  }

  
}
