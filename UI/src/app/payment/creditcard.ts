export class CreditCard{
    constructor(
                public id:number,
                public pinNumber:number,
                public accountId:number,
                public cardNumber:string,
                public expiryDate:string,
                public cvv:number,
                public creditLimit:number,
                public balance:number){}
}