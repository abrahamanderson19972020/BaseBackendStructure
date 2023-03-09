import { CategoryService } from './../../services/category.service';
import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category.model';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories:Category[] = [];
  constructor(private categoryService:CategoryService){

  }
  ngOnInit(): void {
    this.getAllCategories();
  }

  getAllCategories()
  {
    this.categoryService.getCategories().subscribe(res=>{
      if(res)
      {
        this.categories = res.data;
      }
    })
  }

}
