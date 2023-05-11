export class Product{
    constructor(public productId:number,
                public productTitle:string,
                public unitPrice:number,
                public stockAvailable:number,
                public image:string,
                public categoryId:number)
                {}
}