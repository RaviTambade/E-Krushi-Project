export class DebitCard{
    constructor(
                public id:number,
                public customerId:number,
                public pinNumber:number,
                public accountId:number,
                public cardNumber:string,
                public expiryDate:string,
                public cvv:number){}
}
