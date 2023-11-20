import { Component, EventEmitter, Output } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { TokenClaims } from '@enums/tokenclaims';
import { User } from '@models/user';
import { AuthenticationService } from '@services/authentication.service';
import { UserService } from '@services/user.service';

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
  @Output() onUdateFinished = new EventEmitter();

  userForm: FormGroup;

  constructor(
    private svc: UserService,
    private authsvc: AuthenticationService
  ) {
    this.userForm = new FormGroup({
      firstName: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(250),
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(250),
      ]),
      aadharId: new FormControl('', [
        Validators.required,
        Validators.minLength(14),
        Validators.maxLength(14),
        Validators.pattern(/^\d{4}\s?\d{4}\s?\d{4}$/),
      ]),
      birthDate: new FormControl('', [Validators.required]),
      gender: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }
  ngOnInit(): void {
    const userId = Number(this.authsvc.getClaimFromToken(TokenClaims.userId));

    this.userId = userId;
    this.svc.getUser(this.userId).subscribe((response) => {
      this.user = response;
      console.log('🚀 ~ this.svc.getUser ~ response:', response);

      this.userForm.setValue({
        firstName: this.user.firstName,
        lastName: this.user.lastName,
        aadharId: this.user.aadharId,
        birthDate: this.user.birthDate,
        gender: this.user.gender,
        email: this.user.email,
      });
    });

    this.aadharId.valueChanges.subscribe((value) => {
      const formattedValue = value.replace(/(\d{4})(?=\d)/g, '$1 ');
      this.aadharId.setValue(formattedValue, { emitEvent: false });
    });
  }

  get firstname() {
    return this.userForm.get('firstName')!;
  }

  get lastname() {
    return this.userForm.get('lastName')!;
  }

  get email() {
    return this.userForm.get('email')!;
  }

  get aadharId() {
    return this.userForm.get('aadharId')!;
  }

  get dob() {
    return this.userForm.get('birthDate')!;
  }
  get gender() {
    return this.userForm.get('gender')!;
  }

  ngAfterViewInit(): void {
    window.scrollTo(0, document.body.scrollHeight);
  }

  updateUser() {
    if (!this.userId) {
      return;
    }
    const aadharNumber = this.userForm
      .get('aadharId')
      ?.value.replace(/\s/g, '');
      
    if (this.userForm.valid) {
      this.user.firstName = this.firstname.value;
      this.user.lastName = this.lastname.value;
      this.user.aadharId = aadharNumber;
      this.user.birthDate = this.dob.value;
      this.user.gender = this.gender.value;
      this.user.email = this.email.value;

      this.svc.updateUser(this.userId, this.user).subscribe((response) => {
        this.onUdateFinished.emit({ isUpdated: true });
      });
    }
  }

  cancelupdateUser() {
    this.onUdateFinished.emit({ isUpdated: false });
  }
}
