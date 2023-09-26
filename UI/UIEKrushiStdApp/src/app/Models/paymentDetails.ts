export class PaymentDetails {
  constructor(
    public date: string,
    public status: string,
    public total: number,
    public paymentMode: string,
    public paymentId: number
  ) {}
}
