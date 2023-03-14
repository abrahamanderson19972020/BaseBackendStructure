import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './components/product/product.component';
import { CategoryComponent } from './components/category/category.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { HomeComponent } from './components/home/home.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { CustomerComponent } from './components/customer/customer.component';
import { UserComponent } from './components/user/user.component';
import { OrderComponent } from './components/order/order.component';
import { VatPipe } from './pipes/vat.pipe';
import { TextfilterPipe } from './pipes/textfilter.pipe';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CartDetailComponent } from './components/cart-detail/cart-detail.component';
import { ProductAddComponent } from './components/product-add/product-add.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    CategoryComponent,
    NavigationComponent,
    HomeComponent,
    EmployeeComponent,
    CustomerComponent,
    UserComponent,
    OrderComponent,
    VatPipe,
    TextfilterPipe,
    CartSummaryComponent,
    CartDetailComponent,
    ProductAddComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    ToastrModule.forRoot({ timeOut: 2000 }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
