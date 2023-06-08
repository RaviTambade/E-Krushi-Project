import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray} from '@angular/forms';
 
@Component({
  selector: 'mutiple-select-list-box',
  templateUrl: './mutiple-select-list-box.component.html',
  styleUrls: ['./mutiple-select-list-box.component.css']
})
export class MutipleSelectListBoxComponent implements OnInit{
   members:any[];
   selectedmembers:any[];
   result:any;
   selItems:any[];
   form: FormGroup;
  constructor(private formBuilder: FormBuilder){
    this.members=[];
    this.selectedmembers=[];
    this.result="";
    this.selItems=[];
    this.form = this.formBuilder.group({
      members: this.formBuilder.array([])
    })
  }
  ngOnInit(): void {
    //get data from rest api and assign to members
      this.members=["Shiv","Ganesh", "Charu", "Rajiv"];
  }

  changeMembers(e: any){
   this.result=e.target.value;
   
  }

  submit(){
    console.log(this.result);
    //call rest api to store assigned roles to user 
    //in database
    this.selectedmembers.push(this.result);
  }
}
