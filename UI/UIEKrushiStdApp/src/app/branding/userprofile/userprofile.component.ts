import { Component, ElementRef, Input, ViewChild } from '@angular/core';

import { HttpEventType } from '@angular/common/http';
import { User } from '@models/user';
import { MembershipService } from '@services/membership.service';
import { StateChangeEvent } from '@models/stateChangeEvent';
import { AuthenticationService } from '@services/authentication.service';
import { Token } from '@angular/compiler';
import { TokenClaims } from '@enums/tokenclaims';

@Component({
  selector: 'userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css'],
})
export class UserprofileComponent {
 userId!: number;
  user!: User;
  imageServerUrl: string = 'http://localhost:5142/';
  selectedFile: File | undefined;
  selectedImageUrl: string | undefined;
  editingImage: boolean = false;
  defaultImage: string = 'AkshayTanpure.jpg';
  imageurl: string | undefined;

  updateProfileStatus: boolean = false;
  updatePasswordStatus: boolean = false;

  @ViewChild('fileInput') fileInput!: ElementRef<HTMLInputElement>;
  constructor(private membershipSvc: MembershipService,private authSvc:AuthenticationService) {
    this.user = {
      id: 0,
      imageUrl: '',
      aadharId: '',
      firstName: '',
      lastName: '',
      birthDate: '',
      gender: '',
      email: '',
      contactNumber: '',
      password:''
    };
  }

  ngOnInit(): void {

    this.userId=this.authSvc.getClaimFromToken(TokenClaims.userId);
    this.getUser(this.userId);
  }

  getUser(userId: number) {
    this.membershipSvc.getUser(userId).subscribe((response) => {
      this.user = response;
      this.imageurl = this.imageServerUrl + this.user.imageUrl;
    });
  }

  editImage() {
    if (this.fileInput) {
      this.fileInput.nativeElement.click();
    }
  }
  onFileSelected(event: Event) {
    this.editingImage = true;
    const fileInput = event.target as HTMLInputElement;
    this.selectedFile = fileInput.files?.[0];
    if (this.selectedFile)
      this.selectedImageUrl = URL.createObjectURL(this.selectedFile);
  }

  confirmImage() {
    if (this.selectedFile) {
      const formData = new FormData();
      if (this.user.imageUrl == this.defaultImage) {
        this.user.imageUrl =
          crypto.randomUUID() + '.' + this.selectedFile.name.split('.').pop();
      }

      formData.append('file', this.selectedFile, this.user.imageUrl);

      this.membershipSvc.uploadFile(this.user.imageUrl, formData).subscribe({
        next: (event) => {
          if (event.type === HttpEventType.Response) {
            this.imageurl = this.selectedImageUrl;
            this.membershipSvc
              .updateUser(this.user.id, this.user)
              .subscribe((response) => {});
          }
        },
      });

      this.selectedFile = undefined;
      this.editingImage = false;
    }
  }
  cancelImage() {
    this.selectedFile = undefined;
    this.editingImage = false;
  }

  onClickUpdateProfile() {
    this.updateProfileStatus = true;
    this.updatePasswordStatus = false;
  }

  closeEditUserComponent(event: StateChangeEvent) {
    this.updateProfileStatus = false;
    if (event.isStateUpdated) {
      this.getUser(this.user.id);
    }
  }

  onClickUpdatePassword() {
    this.updatePasswordStatus = true;
    this.updateProfileStatus = false;
  }

  closePasswordChangeComponent(event: StateChangeEvent) {
    this.updatePasswordStatus = false;
  }
}
