
export class Order {
    constructor(
        public id:number,
        public orderDate:string,
        public shippeddate:string,
        public total:number, 
        public status:string, 
    ){}
}