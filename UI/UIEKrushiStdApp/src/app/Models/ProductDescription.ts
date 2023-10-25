import { Product } from "./product";
import { ProductDetail } from "./productDetail";

export class ProductDescription extends Product {
    constructor(
      id: number,
      title: string,
      image: string,
      rating: number,
      productDetails: ProductDetail[],
      public description: string,
    ) {
      super(id, title, image, rating, productDetails);
    }
}