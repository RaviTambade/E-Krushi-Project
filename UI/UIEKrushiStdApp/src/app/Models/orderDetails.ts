export class OrderDetails {
    constructor(
        public productId:number,
        public title:string,
        public image:string,
        public size:string,
        public total:number, 
        public quantity:number, 
        public unitPrice:number,
        public status:string,
       
        
    ){}
}