import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TokenClaims } from '@enums/tokenclaims';
import { Address } from '@models/address';
import { NameId } from '@models/nameId';
import { AuthenticationService } from '@services/authentication.service';
import { UserService } from '@services/user.service';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.css'],
})
export class AddAddressComponent implements OnInit {
  addressForm: FormGroup;
  @Output() hideComponent = new EventEmitter();
  user: NameId = {
    id: 0,
    fullName: '',
  };


  constructor(
    private formbuilder: FormBuilder,
    private usersvc: UserService,
    private authsvc: AuthenticationService
  ) {
    this.addressForm = this.formbuilder.group({
      area: ['', Validators.required],
      landmark: [''],
      city: ['', Validators.required],
      state: ['', Validators.required],
      alternateContactNumber: ['', [Validators.pattern('[0-9]+')]],
      pincode: [
        '',
        [
          Validators.required,
          Validators.pattern('[0-9]+'),
          Validators.minLength(6),
        ],
      ],
    });
  }

  ngOnInit(): void {
    let userId = this.authsvc.getClaimFromToken(TokenClaims.userId);

    this.usersvc.getUserNamesWithId(userId).subscribe((response) => {
      this.user = response[0];
      console.log("🚀 ~ this.usersvc.getUserNamesWithId ~ response:", response);
    });
  }

  onSubmit() {
    let address: Address = {
      id: 0,
      userId: this.user.id,
      area: this.addressForm.get('area')?.value,
      landMark: this.addressForm.get('landmark')?.value,
      city: this.addressForm.get('city')?.value,
      state: this.addressForm.get('state')?.value,
      alternateContactNumber: this.addressForm.get('alternateContactNumber')
        ?.value,
      pinCode: this.addressForm.get('pincode')?.value,
    };

    this.usersvc.addAddress(address).subscribe((res) => {
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
