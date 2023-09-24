import { Component } from '@angular/core';

@Component({
  selector: 'app-address-main',
  templateUrl: './address-main.component.html',
  styleUrls: ['./address-main.component.css']
})
export class AddressMainComponent {
  showAddAddress: boolean = false;
  onClickNewAddress() {
    this.showAddAddress = true;
  }

  hideAddressAddComponent() {
    this.showAddAddress = false;
  }
}
