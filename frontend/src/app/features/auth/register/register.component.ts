import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  name = '';
  email = '';
  password = '';
  errorMessage = '';
  isSubmitting = false;

  constructor(private readonly authService: AuthService, private readonly router: Router) {}

  submit(): void {
    this.errorMessage = '';
    this.isSubmitting = true;
    this.authService.register(this.name, this.email, this.password).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.router.navigateByUrl('/');
      },
      error: () => {
        this.errorMessage = 'We could not create your account. Try again with a different email.';
        this.isSubmitting = false;
      }
    });
  }
}
