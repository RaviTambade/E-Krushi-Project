import { ProductDetail } from "./productDetail";

export class Product {
  constructor(
    public id: number,
    public title: string,
    public image: string,
    public rating: number,
    public productDetails: ProductDetail[]
  ) {}
}
