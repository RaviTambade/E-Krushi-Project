export class Address {
  constructor(
    public id: number,
    public userId: number,
    public area: string,
    public landMark: string,
    public city: string,
    public state: string,
    public alternateContactNumber: string,
    public pinCode: string
  ) {}
}
