import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { SessionStorageKeys } from 'src/app/Models/Enums/session-storage-keys';
import { Address } from 'src/app/Models/address';
import { NameId } from 'src/app/Models/nameId';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css'],
})
export class AddressComponent implements OnInit {
  addresses: Address[] = [];
  user: NameId = {
    id: 0,
    name: '',
  };
  @Output() hideComponent = new EventEmitter();
  contactNumber: string | null = null;
  selectedAddressId: number | null = null;
  constructor(
    private usersvc: UserService,
    private authsvc: AuthenticationService
  ) {}
  ngOnInit(): void {
    this.usersvc.newaddressSubject.subscribe(() => {
      this.fetchData();
    });

    this.fetchData();
  }

  fetchData() {
    this.contactNumber = this.authsvc.getContactNumberFromToken();
    if (this.contactNumber === null) {
      return;
    }

    this.usersvc.getUserByContact(this.contactNumber).subscribe((res) => {
      this.user = res;
    });

    let userId: number = Number(localStorage.getItem(LocalStorageKeys.userId));
    this.usersvc.getAddress(userId).subscribe((res) => {
      this.addresses = res;
      this.selectedAddressId = Number(
        sessionStorage.getItem(SessionStorageKeys.addressId)
      );
      if (this.selectedAddressId == null)
        this.selectedAddressId = this.addresses[0].id;
    });
  }

  setAddressId() {
    if (this.selectedAddressId != undefined) {
      sessionStorage.setItem(
        SessionStorageKeys.addressId,
        this.selectedAddressId.toString()
      );
      
      this.hideComponent.emit();
    }
  }
}
