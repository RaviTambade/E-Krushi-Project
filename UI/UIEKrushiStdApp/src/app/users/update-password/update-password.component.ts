import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { UpdatePassword } from '@models/update-password';
import { AuthenticationService } from '@services/authentication.service';

export function confirmPasswordValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    return control.value.newPassword === control.value.confirmPassword
      ? null
      : { PasswordNoMatch: true };
  };
}

@Component({
  selector: 'update-password',
  templateUrl: './update-password.component.html',
  styleUrls: ['./update-password.component.css'],
})
export class UpdatePasswordComponent implements OnInit {
  showOldPassword: boolean = false;
  showNewPassword: boolean = false;
  showConfirmPassword: boolean = false;

  changePasswordForm!: FormGroup;

  @Output() onPasswordChange = new EventEmitter();
  constructor(private authsvc: AuthenticationService) {}

  ngOnInit(): void {
    this.changePasswordForm = new FormGroup(
      {
        oldPassword: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
        ]),
        newPassword: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
        ]),
        confirmPassword: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
        ]),
      },
      { validators: [confirmPasswordValidator()] }
    );
  }

  get oldPassword() {
    return this.changePasswordForm.get('oldPassword')!;
  }
  get newPassword() {
    return this.changePasswordForm.get('newPassword')!;
  }
  get confirmPassword() {
    return this.changePasswordForm.get('confirmPassword')!;
  }

  ngAfterViewInit(): void {
    window.scrollTo(0, document.body.scrollHeight);
  }

  onUpdatePassword() {

    if (this.changePasswordForm.invalid) {
      for (const control of Object.keys(this.changePasswordForm.controls)) {
        this.changePasswordForm.controls[control].markAsTouched();
      }
      return;
    }
    
    let credential: UpdatePassword = {
      oldPassword: this.oldPassword.value,
      newPassword: this.newPassword.value,
    };
    

    this.authsvc.updatePassword(credential).subscribe((response) => {
      if (response) {
        alert('Password changed');
        this.onPasswordChange.emit();
      }
    });
  }

  onCancelClick() {
    this.onPasswordChange.emit();
  }
}
