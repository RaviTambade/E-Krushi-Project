export class PaymentDetails {
  constructor(
    public date: Date,

    public status: string,
    public total :number,
    public paymentMode: string,
    public paymentId:number
        
  ) {}
}
