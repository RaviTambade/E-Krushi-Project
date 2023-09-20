import { Product } from './product';

export class ProductDetail extends Product {
  constructor(
    id: number,
    title: string,
    image: string,
    rating: number,
    unitPrice: number,
    size: string[],
    public description: string,
  ) {
    super(id, title, image, rating, unitPrice, size);
  }
}
