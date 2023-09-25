export class PaymentAddModel {
  constructor(
    public paymentStatus: string,
    public mode: string,
    public orderId: number,
    public transactionId: number
  ) {}
}
