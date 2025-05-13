import { Component } from '@angular/core';
import {ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from '../auth.service';
import { Router,RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,HttpClientModule, RouterModule],
  providers: [AuthService],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';
  isSubmitting = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.invalid) return;

    this.isSubmitting = true;
    this.errorMessage = '';

    const { email, password } = this.loginForm.value;

    this.authService.login(email, password).subscribe({
      next: (res: any) => {
        this.isSubmitting = false;

        // Store token
        localStorage.setItem('token', res.token);

        // Decode token or use role info from backend response
        const role = res.role?.toLowerCase();
        //const role = this.authService.getUserRole();

        if (role === 'admin') {
          this.router.navigate(['/admin-dashboard']);
        } else if (role === 'student') {
          this.router.navigate(['/student-dashboard']);
        } else if (role === 'teacher') {
          this.router.navigate(['/teacher-dashboard']);
        } else {
          this.router.navigate(['/']);  //fallback
        }
      },
      error: (err) => {
        this.isSubmitting = false;
        this.errorMessage = err.error?.message || 'Login failed. Please try again.';
      }
    });
  }
}