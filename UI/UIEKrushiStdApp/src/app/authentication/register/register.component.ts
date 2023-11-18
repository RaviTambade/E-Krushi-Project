import { Component } from '@angular/core';
import {
  ValidatorFn,
  AbstractControl,
  ValidationErrors,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { IUser } from '@ekrushi-authentication/iuser';
import { User } from '@models/user';
import { UserService } from '@services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  reactiveForm!: FormGroup;

  showPassword: boolean = false;
  user: IUser;
  constructor( private usersvc:UserService) {
    this.user = {} as IUser;
  }

  ngOnInit(): void {
    this.reactiveForm = new FormGroup({
      firstName: new FormControl(this.user.firstName, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(250),
      ]),
      lastName: new FormControl(this.user.lastName, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(250),
      ]),
      contactNumber: new FormControl(this.user.contactNumber, [
        Validators.required,
        Validators.pattern(/^\d{10}$/),
        Validators.minLength(10),
        Validators.maxLength(10),
      ]),
      email: new FormControl(this.user.email, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(250),
        Validators.email,
      ]),
      aadharId: new FormControl(this.user.aadharId, [
        Validators.required,
        Validators.minLength(14),
        Validators.maxLength(14),
        Validators.pattern(/^\d{4}\s?\d{4}\s?\d{4}$/),
      ]),

      birthDate: new FormControl(this.user.birthDate, [Validators.required]),
      gender: new FormControl(this.user.gender, [Validators.required]),
      password: new FormControl(this.user.password, [
        Validators.required,
        Validators.minLength(8),
      ]),
    });

    this.aadharId.valueChanges.subscribe((value) => {
      const formattedValue = value.replace(/(\d{4})(?=\d)/g, '$1 ');
      this.aadharId.setValue(formattedValue, { emitEvent: false });
    });
  }

  get firstname() {
    return this.reactiveForm.get('firstName')!;
  }

  get lastname() {
    return this.reactiveForm.get('lastName')!;
  }

  get email() {
    return this.reactiveForm.get('email')!;
  }
  get contactnumber() {
    return this.reactiveForm.get('contactNumber')!;
  }

  get password() {
    return this.reactiveForm.get('password')!;
  }
  get aadharId() {
    return this.reactiveForm.get('aadharId')!;
  }

  get dob() {
    return this.reactiveForm.get('birthDate')!;
  }

  public validate(): void {
    if (this.reactiveForm.invalid) {
      for (const control of Object.keys(this.reactiveForm.controls)) {
        this.reactiveForm.controls[control].markAsTouched();
      }
      return;
    }

    let user = this.reactiveForm.value;
    const aadharNumber = this.reactiveForm
      .get('aadharId')
      ?.value.replace(/\s/g, '');

      // this.usersvc.addUser()
    console.info('aadhar', aadharNumber);
    console.info('Name:', user.firstName);
    console.info('Lastname:', user.lastName);
    console.info('Email:', user.email);
  }
}
