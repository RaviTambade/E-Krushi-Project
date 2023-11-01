import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'supplier-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {

  userForm: FormGroup;

 


  constructor(
    private svc: UserService,
    private authsvc: AuthenticationService,
    private fb: FormBuilder
  ) {
    this.userForm = this.fb.group({
      title: ['', [Validators.required,Validators.minLength(1)]],
      description: ['',[ Validators.required,Validators.minLength(1)]],
      categoryId: ['', Validators.required],
      
    });
  }
  ngOnInit(): void {

  }



  

  updateUser() {
  //   if (!this.userId) {
  //     return;
  //   }
  //   if (this.userForm.valid) {
  //     this.user.firstName=this.userForm.get('firstName')?.value;
  //     this.user.lastName=this.userForm.get('lastName')?.value;
  //     this.user.aadharId=this.userForm.get('aadharId')?.value;
  //     this.user.birthDate=this.userForm.get('birthDate')?.value;
  //     this.user.gender=this.userForm.get('gender')?.value;
  //     this.user.email=this.userForm.get('email')?.value;
  //   this.svc.updateUser(this.userId, this.user).subscribe((response) => {
  //     console.log(response);
  //   this.onUdateFinished.emit({isUpdated:true});
  // });
  // }
  }

  cancelupdateUser(){
    // this.onUdateFinished.emit({isUpdated:false});
  }


}
