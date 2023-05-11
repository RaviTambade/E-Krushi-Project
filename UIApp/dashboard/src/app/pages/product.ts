export class Product{
    constructor(public productId:number,
                public title:string,
                public unitPrice:number,
                public stockAvailable:number,
                public image:string,
                public categoryId:number)
                {}
}