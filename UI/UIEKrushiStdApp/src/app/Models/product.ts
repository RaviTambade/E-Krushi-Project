export class Product {
  constructor(
    public id: number,
    public title: string,
    public image: string,
    public rating: number,
    public unitPrice: number,
    public size: string[]
  ) {}
}
