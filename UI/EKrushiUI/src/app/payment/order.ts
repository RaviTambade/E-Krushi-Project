
export class Order{
    constructor(public Id:number,
                public orderDate:Date,
                public shippedDate:Date,
                public custId:number,
                public total:number,
                public status:string){}
}