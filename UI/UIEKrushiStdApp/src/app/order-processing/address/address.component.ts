import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeleteConfirmationComponent } from '@ekrushi-confirmationboxes/delete-confirmation/delete-confirmation.component';
import { SessionStorageKeys } from '@enums/session-storage-keys';
import { TokenClaims } from '@enums/tokenclaims';
import { Address } from '@models/address';
import { AuthenticationService } from '@services/authentication.service';
import { UserService } from '@services/user.service';
import { StateChangeEvent } from 'membership-lib/lib/stateChangeEvent';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css'],
})
export class AddressComponent implements OnInit {
  addresses: Address[] = [];
  @Output() hideComponent = new EventEmitter();
  selectedAddressId: number | null = null;
  showAddAddress: boolean = false;
  showupdateAddress: boolean = false;
  userId!: number;

  selectedUpdateId: number | undefined;

  constructor(
    private usersvc: UserService,
    private authsvc: AuthenticationService,
    private dialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.fetchAddresses();
  }

  fetchAddresses() {
    this.userId = Number(this.authsvc.getClaimFromToken(TokenClaims.userId));
    this.usersvc.getAddressOfUser(this.userId).subscribe((res) => {
      this.addresses = res;
      this.selectedAddressId = Number(
        sessionStorage.getItem(SessionStorageKeys.addressId)
      );

      if (Number.isNaN(this.selectedAddressId) || this.selectedAddressId == 0)
        this.selectedAddressId = this.addresses[0].id;
    });
  }

  onClickUpdateAddress(id: number) {
    this.selectedUpdateId = id;
    this.showupdateAddress = true;
  }

  onClickNewAddress() {
    this.showAddAddress = true;
  }

  hideAddAddressComponent(event: StateChangeEvent) {
    this.showAddAddress = false;
    if (event.isStateUpdated) {
      this.fetchAddresses();
    }
  }

  hideUpdateAddressComponent(event: StateChangeEvent) {
    this.showupdateAddress = false;
    this.selectedUpdateId = undefined;
    if (event.isStateUpdated) {
      this.fetchAddresses();
    }
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

  openDeleteAddressConfirmationDialog(productDetailsId: number) {
    const dialogRef = this.dialog.open(DeleteConfirmationComponent, {
      data: 'Address',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === true) {
        this.deleteAddress(productDetailsId);
      }
    });
  }

  deleteAddress(addressId: number) {
    this.usersvc.deleteAddress(addressId).subscribe((res) => {
      if (res == true) {
        this.addresses = this.addresses.filter(
          (address) => address.id != addressId
        );

        if (this.selectedAddressId == addressId) {
          sessionStorage.removeItem(SessionStorageKeys.addressId);
          this.selectedAddressId = this.selectedAddressId =
            this.addresses[0].id;
        }
      }
    });
  }
}
