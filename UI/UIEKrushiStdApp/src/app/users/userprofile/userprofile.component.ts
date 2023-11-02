import { Component, ElementRef, ViewChild } from '@angular/core';
import { UUID } from 'angular2-uuid';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { UserService } from 'src/app/Services/user.service';
import { User } from 'src/app/Models/user';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css'],
})
export class UserprofileComponent {
  user: User;
  message: string | undefined;
  progress: number = 0;
  url: string = 'http://localhost:5102/';
  selectedFile: File | undefined;
  selectedImageUrl: string | undefined;
  editingImage: boolean = false;
  defaultImage: string = 'AkshayTanpure.jpg';
  imageurl: string | undefined;

  updateProfileStatus: boolean = false;
  updatePasswordStatus: boolean = false;

  @ViewChild('fileInput') fileInput!: ElementRef<HTMLInputElement>;
  constructor(
    private usersvc: UserService,
    private http: HttpClient
  ) {
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
    };
  }

  ngOnInit(): void {
    const userId = Number(localStorage.getItem(LocalStorageKeys.userId)); // this.authsvc.getUserIdFromToken();
    if (Number.isNaN(userId) || userId == 0) {
      return;
    }
    this.getUser(userId);
  }

  getUser(userId: number) {
    this.usersvc.getUser(userId).subscribe((response) => {
      this.user = response;
      this.imageurl = this.url + this.user.imageUrl;
     
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
          UUID.UUID() + '.' + this.selectedFile.name.split('.').pop();
      }
      formData.append('file', this.selectedFile, this.user.imageUrl);
      this.http
        .post(
          'http://localhost:5102/api/users/fileupload/' + this.user.imageUrl,
          formData,
          {
            reportProgress: true,
            observe: 'events',
          }
        )
        .subscribe({
          next: (event) => {
            if (event.type === HttpEventType.UploadProgress && event.total) {
              this.progress = Math.round((100 * event.loaded) / event.total);
            }
            if (event.type === HttpEventType.Response) {
              this.message = 'Upload success.';
              this.imageurl = this.selectedImageUrl;
              this.usersvc
                .updateUser(this.user.id, this.user)
                .subscribe((response) => {
                 
                });
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
    this.updatePasswordStatus = false

  }

  closeEditUserComponent(event: any) {
    this.updateProfileStatus = false;
    if (event.isUpdated) {
      this.getUser(this.user.id);
    }
  }

  onClickUpdatePassword() {
    this.updatePasswordStatus = true;
    this.updateProfileStatus = false;

  }

  closePasswordChangeComponent(){
    this.updatePasswordStatus = false
  }
}
