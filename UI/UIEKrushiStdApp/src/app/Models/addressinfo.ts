export class AddressInfo {
    constructor(
      public id: number,
      public name: string,
      public contactNumber: string,
      public area: string,
      public landMark: string,
      public city: string,
      public state: string,
      public alternateContactNumber: string,
      public pinCode: string
    ) {}

    toString(): string {
      return `${this.name}, ${this.landMark}, ${this.area},${this.city}, ${this.state},${this.pinCode} ,${this.contactNumber}, ${this.alternateContactNumber}`;
  }
  }