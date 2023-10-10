export class ShipperOrder {
    constructor(
        public orderId: number,
        public fromAddressId: number,
        public toAddressId: number,
        public status: string,
        public fromAddress: string,
        public toAddress: string,
        public orderDate: string,
        public shippedDate: string
    ) {}
  }
  