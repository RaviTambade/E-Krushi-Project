import { Item } from "./items";

export class Cart {
    constructor(public cartId:number,
                public items:Item[]){}
}

