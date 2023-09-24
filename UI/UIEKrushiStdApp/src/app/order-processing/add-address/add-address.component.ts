import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Address } from 'src/app/Models/address';
import { NameId } from 'src/app/Models/nameId';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { UserService } from 'src/app/Services/user.service';

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
    name: '',
  };
  contactNumber: string | null = null;

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
    this.contactNumber = this.authsvc.getContactNumberFromToken();
    if (this.contactNumber === null) {
      return;
    }
    this.usersvc.getUserByContact(this.contactNumber).subscribe((res) => {
      this.user = res;
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
    console.log(address);
    this.usersvc.addAddress(address).subscribe((res) => {
      if (res) {
        this.hideComponent.emit();
        this.usersvc.newaddressSubject.next();
        console.log('address added Sucessfully');
      }
    });
  }
  onCancelClick() {
    this.hideComponent.emit();
  }
}
