import { OrderService } from './../../services/order.service';
import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order.model';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent implements OnInit {
  public orders: Order[] = [];
  public dataLoaded:boolean = false;
  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.getAllOrders();
  }

  getAllOrders() {
    this.orderService.getOrders().subscribe((res) => {
      if (res) {
        this.orders = res.data;
        this.dataLoaded = true;
      }
    });
  }
}
