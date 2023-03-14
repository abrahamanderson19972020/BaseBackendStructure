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

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'products', component: ProductComponent },
  { path: 'products/add', component: ProductAddComponent },
  { path: 'products/:categoryId', component: ProductComponent },
  { path: 'employees', component: EmployeeComponent },
  { path: 'orders', component: OrderComponent },
  { path: 'user', component: UserComponent },
  { path: 'customers', component: CustomerComponent },
  { path: 'cart', component: CartDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
