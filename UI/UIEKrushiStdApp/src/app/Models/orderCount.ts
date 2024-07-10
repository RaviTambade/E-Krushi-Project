export class OrderCount{
    constructor(
        public todaysOrders:number,
        public yesterdaysOrders:number,
        public weekOrders:number,
        public monthOrders:number
      ) {}
}