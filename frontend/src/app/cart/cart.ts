import { Item } from "./items";

export class Cart{
 constructor(
    public id:number,
    public items: Item[]
 )
 {}
}