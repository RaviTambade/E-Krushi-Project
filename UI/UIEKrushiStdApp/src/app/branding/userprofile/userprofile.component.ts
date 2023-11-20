import { Component} from '@angular/core';
import { AuthenticationService } from '@services/authentication.service';
import { TokenClaims } from '@enums/tokenclaims';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css'],
})
export class UserprofileComponent {
  userId!: number;

  constructor(private authsvc: AuthenticationService) {}

  ngOnInit(): void {
    this.userId = Number(this.authsvc.getClaimFromToken(TokenClaims.userId));
  }
}
