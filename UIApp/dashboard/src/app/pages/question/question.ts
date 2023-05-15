export class Question{
    constructor(
                 public questionId : number,
                 public questionDate : Date,
                 public description : string,
                 public custId : number,
                 public categoryId : number,
                )
                {}
}