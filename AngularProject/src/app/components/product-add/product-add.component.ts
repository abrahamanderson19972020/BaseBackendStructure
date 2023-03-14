import { ToastrModule, ToastrService } from 'ngx-toastr';
import { ProductService } from 'src/app/services/product.service';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css'],
})
export class ProductAddComponent implements OnInit {
  productAddForm!: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private router: Router,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createProductAddForm();
  }

  createProductAddForm() {
    this.productAddForm = this.formBuilder.group({
      categoryId: ['', Validators.required],
      productName: ['', Validators.required],
      unitsInStock: ['', Validators.required],
      unitPrice: ['', Validators.required],
    });
  }

  onAddProduct() {
    console.log(this.productAddForm.value);
    if (this.productAddForm.valid) {
      this.productService.addProduct(this.productAddForm.value).subscribe(
        (res) => {
          console.log(res);
          this.toastrService.success(res.message, 'Success');
          this.productAddForm.reset();
          this.router.navigate(['products']);
        },
        (error) => {
          alert(error.error.message);
          console.log(error);
        }
      );
    } else {
      this.toastrService.error('Product Add Form is not valid!', 'Error');
      //throw error for invalid form
      this.validateAllFormFields(this.productAddForm);
    }
  }

  private validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach((field) => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }
}
