import { Component, EventEmitter, Output } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { User } from 'src/app/Models/user';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css'],
})
export class EdituserComponent {
  user: User = {
    id: 0,
    imageUrl: '',
    aadharId: '',
    firstName: '',
    lastName: '',
    birthDate: '',
    gender: '',
    email: '',
    contactNumber: '',
  };
  userId: number | null = null;
  url: any = 'http://localhost:5102/' + this.user.imageUrl;
  @Output() onUdateFinished = new EventEmitter();

  userForm: FormGroup;

 


  constructor(
    private svc: UserService,
    private authsvc: AuthenticationService,
    private fb: FormBuilder
  ) {
    this.userForm = this.fb.group({
      firstName: ['', [Validators.required,Validators.minLength(1)]],
      lastName: ['',[ Validators.required,Validators.minLength(1)]],
      aadharId: ['', Validators.required],
      birthDate: ['', Validators.required],
      gender: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }
  ngOnInit(): void {
    const userId = Number(localStorage.getItem(LocalStorageKeys.userId));   // this.authsvc.getUserIdFromToken();
    if (Number.isNaN(userId) || userId == 0) {
      return;
    }
    this.userId=userId;
    this.svc.getUser(this.userId).subscribe((response) => {
      this.user = response;

      this.userForm.setValue({
        firstName: this.user.firstName,
        lastName: this.user.lastName,
        aadharId: this.user.aadharId,
        birthDate: this.user.birthDate,
        gender: this.user.gender,
        email: this.user.email
      });
     
    });
  }

  ngAfterViewInit(): void{
    window.scrollTo(0,document.body.scrollHeight);
  }

  

  updateUser() {
    if (!this.userId) {
      return;
    }
    if (this.userForm.valid) {
      this.user.firstName=this.userForm.get('firstName')?.value;
      this.user.lastName=this.userForm.get('lastName')?.value;
      this.user.aadharId=this.userForm.get('aadharId')?.value;
      this.user.birthDate=this.userForm.get('birthDate')?.value;
      this.user.gender=this.userForm.get('gender')?.value;
      this.user.email=this.userForm.get('email')?.value;
    this.svc.updateUser(this.userId, this.user).subscribe((response) => {
     
    this.onUdateFinished.emit({isUpdated:true});
  });
  }
  }

  cancelupdateUser(){
    this.onUdateFinished.emit({isUpdated:false});
  }

}
