import { Component, EventEmitter, Output } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import {
  HttpClient,
  HttpErrorResponse,
  HttpEventType,
} from '@angular/common/http';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { LocalStorageKeys } from 'src/app/Models/Enums/local-storage-keys';
import { User } from 'src/app/Models/user';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css'],
})
export class EdituserComponent {
  user: User = {
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
  userId: number | null = null;
  message: string | undefined;
  filename: string | any;
  progress: number = 0;
  url: any = 'http://localhost:5102/' + this.user.imageUrl;
  @Output() public onUploadFinished = new EventEmitter();
  constructor(
    private svc: UserService,
    private http: HttpClient,
    private authsvc: AuthenticationService
  ) {}
  ngOnInit(): void {
    const userId = Number(localStorage.getItem(LocalStorageKeys.userId));   // this.authsvc.getUserIdFromToken();
    if (Number.isNaN(userId) || userId == 0) {
      return;
    }
    this.userId=userId;
    this.svc.getUser(this.userId).subscribe((response) => {
      this.user = response;
      console.log(response);
    });
  }

  

  updateUser() {
    if (!this.userId) {
      return;
    }
    this.svc.updateUser(this.userId, this.user).subscribe((response) => {
      // this.url=this.user.imageUrl
      console.log(response);
    });
  }
}
