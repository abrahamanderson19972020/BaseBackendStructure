import { CartItem } from './../models/cartItem.model';
import { CartItems } from './../models/CartItems.model';
import { Product } from './../models/product.model';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor() {}

  addToCart(product: Product) {
    var item = CartItems.find((c) => c.product.productId === product.productId);
    if (item) {
      item.quantity += 1;
    } else {
      const newItem: CartItem = { product: product, quantity: 1 };
      CartItems.push(newItem);
    }
  }

  listCart(): CartItem[] {
    return CartItems;
  }

  deleteFromCart(product: Product) {
    var item = CartItems.find((c) => c.product.productId === product.productId);
    if (item) {
      const index = CartItems.indexOf(item, 0);
      CartItems.splice(index, 1);
    }
  }
}
