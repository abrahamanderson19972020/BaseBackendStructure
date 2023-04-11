import { ToastrService } from 'ngx-toastr';
import { UserService } from './../../services/user.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  login() {
    if (this.loginForm.valid) {
      this.userService.login(this.loginForm.value).subscribe(
        (res) => {
          console.log(res);
          this.toastrService.success(res.message, 'Success');
          localStorage.setItem('token', res.data.token);
          this.loginForm.reset();
          setTimeout(() => {
            this.router.navigate(['products']);
          }, 100);
        },
        (error) => {
          this.toastrService.error('Authentication fail', 'Error');
          console.log(error);
        }
      );
    } else {
      this.toastrService.error('Login Form is not valid!', 'Error');
      //throw error for invalid form
      this.validateAllFormFields(this.loginForm);
    }
  }

  register() {
    this.router.navigate(['register']);
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
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
