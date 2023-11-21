import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TokenClaims } from '@enums/tokenclaims';
import { Address } from '@models/address';
import { AuthenticationService } from '@services/authentication.service';
import { UserService } from '@services/user.service';

@Component({
  selector: 'app-update-address',
  templateUrl: './update-address.component.html',
  styleUrls: ['./update-address.component.css'],
})
export class UpdateAddressComponent {
  addressForm!: FormGroup;
  @Output() hideComponent = new EventEmitter();
  @Input() address!: Address;
  constructor(
    private usersvc: UserService,
    private authsvc: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.addressForm = new FormGroup({
      area: new FormControl(this.address.area, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(50),
      ]),
      landmark: new FormControl(this.address.landMark),
      addressType: new FormControl(this.address.addressType, [Validators.required]),
      city: new FormControl(this.address.city, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(20),
      ]),
      state: new FormControl(this.address.state, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(20),
      ]),
      pincode: new FormControl(this.address.pinCode, [
        Validators.required,
        Validators.pattern('[0-9]+'),
        Validators.minLength(6),
        Validators.maxLength(6),
      ]),
    });
  }

  get area() {
    return this.addressForm.get('area')!;
  }
  get landmark() {
    return this.addressForm.get('landmark')!;
  }
  get city() {
    return this.addressForm.get('city')!;
  }
  get state() {
    return this.addressForm.get('state')!;
  }
  get addressType() {
    return this.addressForm.get('addressType')!;
  }
  get pincode() {
    return this.addressForm.get('pincode')!;
  }

  onSubmit() {
    if (this.addressForm.invalid) {
      for (const control of Object.keys(this.addressForm.controls)) {
        this.addressForm.controls[control].markAsTouched();
      }
      return;
    }

    let address: Address = {
      id: this.address.id,
      userId: this.authsvc.getClaimFromToken(TokenClaims.userId),
      area: this.area.value,
      landMark: this.landmark.value,
      city: this.city.value,
      state: this.state.value,
      addressType: this.addressType.value,
      pinCode: this.pincode.value,
      name: this.address.name,
      contactNumber: this.address.contactNumber,
    };


    this.usersvc.updateAddress(address.id,address).subscribe((res) => {
      if (res) {
        this.hideComponent.emit();
        this.usersvc.newaddressSubject.next();
      }
    });
  }
  onCancelClick() {
    this.hideComponent.emit();
  }
}
