export class CartItem {
  constructor(
    public cartItemId: number,
    public productId: number,
    public title: string,
    public size: string,
    public image: string,
    public quantity: number,
    public unitPrice: number,
  ) {
    
  }
}
