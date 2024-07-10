
export class OrderedItem{
    constructor(
        public orderid:number,
        public imageUrl:string,
        public title:string,
        public size:string,
        public price:number,
        public quantity:number,
        public total:number,
    ){}
}