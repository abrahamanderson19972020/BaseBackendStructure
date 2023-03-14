import { CartService } from './../../services/cart.service';
import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/cartItem.model';

@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
  styleUrls: ['./cart-detail.component.css']
})
export class CartDetailComponent implements OnInit{
   cartDetails:CartItem[] = [];
  constructor(private cartService:CartService){}

  ngOnInit(): void {
    this.getCartDetails();
  }

  getCartDetails()
  {
    this.cartDetails = this.cartService.listCart();
  }

}
