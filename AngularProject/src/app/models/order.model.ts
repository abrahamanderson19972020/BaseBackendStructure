export interface Order {
  orderId: number;
  customerId: string;
  employeeId: number;
  orderDate: Date;
  shippedDate: Date;
  shipName: string;
  shipAddress: string;
  shipCity: string;
  shipCountry: string;
  shipPostalCode: string;
}
