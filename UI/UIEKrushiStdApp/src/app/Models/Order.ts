
export class Order {
    constructor(
        public id:number,
        public orderDate:string,
        public total:number, 
        public status:string, 
    ){}
}