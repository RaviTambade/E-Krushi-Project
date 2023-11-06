import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { LocalStorageKeys } from '@enums/local-storage-keys';
import { SessionStorageKeys } from '@enums/session-storage-keys';
import { AddressInfo } from '@models/addressinfo';
import { UserService } from '@services/user.service';


@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css'],
})
export class AddressComponent implements OnInit {
  addresses: AddressInfo[] = [];
  @Output() hideComponent = new EventEmitter();
  selectedAddressId: number | null = null;
  constructor(
    private usersvc: UserService,
  ) {}
  ngOnInit(): void {
    this.usersvc.newaddressSubject.subscribe(() => {
      this.fetchData();
    });

    this.fetchData();
  }

  fetchData() {
    let userId: number = Number(localStorage.getItem(LocalStorageKeys.userId));
    this.usersvc.getAddress(userId).subscribe((res) => {
      this.addresses = res;
      this.selectedAddressId = Number(
        sessionStorage.getItem(SessionStorageKeys.addressId)
      );
    

      if (
        Number.isNaN(this.selectedAddressId) || this.selectedAddressId==0
      )
        this.selectedAddressId = this.addresses[0].id;
    });
  }

  onClickDeliverHere() {
    if (this.selectedAddressId != undefined) {
      sessionStorage.setItem(
        SessionStorageKeys.addressId,
        this.selectedAddressId.toString()
      );

      this.hideComponent.emit({
        address: this.addresses
          .filter((a) => a.id == Number(this.selectedAddressId))
          .at(0),
      });
    }
  }
}
