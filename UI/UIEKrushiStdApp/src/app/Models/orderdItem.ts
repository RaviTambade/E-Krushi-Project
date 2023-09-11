
export class OrderedItem{
    constructor(
        public orderid:number,
        public image:string,
        public title:string,
        public amount:number,
        public quantity:number,
        public total:number,
    ){}
}