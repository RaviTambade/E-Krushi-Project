export class Order{
    constructor(
                public count : number,
                public orderId : number,
                public orderDate : Date,
                public shippedDate : Date,
                public customerId : number,
                public total : number,
                public status : string)
                {}
}