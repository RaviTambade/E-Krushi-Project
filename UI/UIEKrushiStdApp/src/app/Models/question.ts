export class Question {
    constructor(
      public id: number,
      public description: string,
      public categoryId: number,
      public date:string,
      public customerId: number,
      public name:string,
    ) {}
  }