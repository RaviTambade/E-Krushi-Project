export class Payment {
    constructor(
      public paymentDate: Date,
      public paymentStatus: string,
      public orderId :number
    ) {}
  }
  