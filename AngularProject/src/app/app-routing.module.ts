import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './components/product/product.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { UserComponent } from './components/user/user.component';
import { CustomerComponent } from './components/customer/customer.component';
import { OrderComponent } from './components/order/order.component';
import { CartDetailComponent } from './components/cart-detail/cart-detail.component';
import { ProductAddComponent } from './components/product-add/product-add.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginGuard } from './guards/login.guard';
import { AboutComponent } from './components/about/about.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'products', component: ProductComponent },
  {
    path: 'products/add',
    component: ProductAddComponent,
    canActivate: [LoginGuard],
  },
  { path: 'products/:categoryId', component: ProductComponent },
  {
    path: 'employees',
    component: EmployeeComponent,
    canActivate: [LoginGuard],
  },
  { path: 'orders', component: OrderComponent, canActivate: [LoginGuard] },
  { path: 'user', component: UserComponent, canActivate: [LoginGuard] },
  {
    path: 'customers',
    component: CustomerComponent,
    canActivate: [LoginGuard],
  },
  { path: 'cart', component: CartDetailComponent, canActivate: [LoginGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
