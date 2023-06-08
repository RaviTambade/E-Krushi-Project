import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray} from '@angular/forms';
 
@Component({
  selector: 'mutiple-select-list-box',
  templateUrl: './mutiple-select-list-box.component.html',
  styleUrls: ['./mutiple-select-list-box.component.css']
})
export class MutipleSelectListBoxComponent implements OnInit{
   members:any[];
   result:any[];
   selItems:any[];
   form: FormGroup;
   selMembers:any ;
  constructor(private formBuilder: FormBuilder){
    this.members=[];
    this.result=[];
    this.selItems=[];
    this.form = this.formBuilder.group({
      members: this.formBuilder.array([])

      
    })
  }


  ngOnInit(): void {
    //get data from rest api and assign to members
      this.members=["Shiv","Ganesh", "Charu", "Rajiv"];
      this.selMembers= new FormControl("",Validators.required)
  }

  changeMembers(e: any){
  //  this.selItems=e.target.value;
  //   if(!this.selItems.includes(e)){
  //     this.selItems.push(e);
  //   }
  //  console.log(this.selItems);
  }

  submit(){
    console.log(this.result);
   this.selItems= this.selMembers.value;
   console.log(this.selItems);

    //call rest api to store assigned roles to user 
    //in database
  }
}
