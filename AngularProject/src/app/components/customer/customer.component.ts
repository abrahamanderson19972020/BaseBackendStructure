import { CustomerService } from './../../services/customer.service';
import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  customers: Customer[] = [];
  dataLoaded:boolean = false;

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.getAllCustomers();
  }

  getAllCustomers() {
    this.customerService.getCustomers().subscribe((res) => {
      if (res) {
        this.customers = res.data;
        this.dataLoaded = true;
      }
    });
  }
}
