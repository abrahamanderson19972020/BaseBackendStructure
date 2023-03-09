import { ProductResponse } from './../../models/productResponse.model';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  public dataLoaded: boolean = false;
  constructor(private productService: ProductService) {}
  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts() {
    this.productService.getProducts().subscribe((res) => {
      if (res) {
        this.products = res.data;
        this.dataLoaded = true;
      }
    });
  }
}
