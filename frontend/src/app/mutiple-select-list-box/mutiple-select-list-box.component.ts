import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray} from '@angular/forms';
 
@Component({
  selector: 'mutiple-select-list-box',
  templateUrl: './mutiple-select-list-box.component.html',
  styleUrls: ['./mutiple-select-list-box.component.css']
})
export class MutipleSelectListBoxComponent implements OnInit{
   members:any[];
<<<<<<< HEAD
   selectedmembers:any[];
   result:any;
=======
   result:any[];
>>>>>>> b1cd0b7aac866e23fdb91c4a1b5e57346781bd80
   selItems:any[];
   form: FormGroup;
   selMembers:any ;
  constructor(private formBuilder: FormBuilder){
    this.members=[];
<<<<<<< HEAD
    this.selectedmembers=[];
    this.result="";
=======
    this.result=[];
>>>>>>> b1cd0b7aac866e23fdb91c4a1b5e57346781bd80
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
<<<<<<< HEAD
   this.result=e.target.value;
   
=======
  //  this.selItems=e.target.value;
  //   if(!this.selItems.includes(e)){
  //     this.selItems.push(e);
  //   }
  //  console.log(this.selItems);
>>>>>>> b1cd0b7aac866e23fdb91c4a1b5e57346781bd80
  }

  submit(){
    console.log(this.result);
   this.selItems= this.selMembers.value;
   console.log(this.selItems);

    //call rest api to store assigned roles to user 
    //in database
    this.selectedmembers.push(this.result);
  }
}
