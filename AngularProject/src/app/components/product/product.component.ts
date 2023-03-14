import { CartService } from './../../services/cart.service';
import { CartItems } from './../../models/CartItems.model';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';
import { Category } from 'src/app/models/category.model';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  public dataLoaded: boolean = false;
  filterText: string = '';
  selectedOption1: string = '1';
  selectedOption2: string = '2';
  selectedOption3: string = '3';

  constructor(
    private productService: ProductService,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((par) => {
      console.log(par['categoryId']);
      if (par['categoryId']) {
        this.getProductsByCategory(par['categoryId']);
      } else {
        this.getAllProducts();
      }
    });
  }

  getAllProducts() {
    this.productService.getProducts().subscribe((res) => {
      if (res) {
        this.products = res.data;
        this.dataLoaded = true;
      }
    });
  }

  getProductsByCategory(categoryId: number) {
    this.productService.getProductsByCategory(categoryId).subscribe((res) => {
      this.products = res.data;
      this.dataLoaded = true;
    });
  }

  addToCart(product: Product) {
    this.toastr.success('Added to Cart', product.productName);
    this.cartService.addToCart(product);
  }
}
