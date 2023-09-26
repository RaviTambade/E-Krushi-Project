import { OrderDetailsAddModel } from './order-details-add-model';

export class OrderAddModel {
  constructor(
    public customerId: number,
    public addressId: number,
    public orderDetails: OrderDetailsAddModel[]
  ) {}
}
