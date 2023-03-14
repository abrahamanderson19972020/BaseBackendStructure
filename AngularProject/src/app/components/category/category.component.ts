import { ProductService } from './../../services/product.service';
import { CategoryService } from './../../services/category.service';
import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category.model';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
})
export class CategoryComponent implements OnInit {
  categories: Category[] = [];
  activeCategory: Category | undefined;
  productsByCategory: Product[] = [];
  allClasses: boolean = true;

  constructor(private categoryService: CategoryService) {}
  ngOnInit(): void {
    this.getAllCategories();
  }

  getAllCategories() {
    this.categoryService.getCategories().subscribe((res) => {
      if (res) {
        this.categories = res.data;
      }
    });
  }

  setActiveCategory(category: Category) {
    this.activeCategory = category;
  }

  setCurrentCategoryClass(category: Category) {
    if (category === this.activeCategory) {
      {
        return 'list-group-item active';
      }
    } else {
      return 'list-group-item';
    }
  }
  setAllCategoryClass() {
    if (!this.activeCategory) return 'list-group-item active';
    else {
      return 'list-group-item';
    }
  }
}
