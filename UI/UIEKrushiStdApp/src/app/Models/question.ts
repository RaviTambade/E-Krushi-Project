export class Question {
    constructor(
      public id: number,
      public description: string,
      public categoryId: number,
      public date:Date,
      public customerId: number,
      public name:string,
    ) {}
  }