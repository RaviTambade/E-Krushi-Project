export class OrderStatusCount {
  constructor(
    public pending: number,
    public approved: number,
    public readyToDispatch: number,
    public picked: number,
    public inProgress: number,
    public delivered: number,
    public cancelled: number
  ) {}
}
