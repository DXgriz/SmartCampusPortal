import { Component } from '@angular/core';
import { Router } from '@angular/router'; 


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private router: Router) { }

  // Navigate to the login page
  navigateToLogin(): void {
    this.router.navigate(['/auth/login']);
  }

  // Navigate to the registration page
  navigateToRegister(): void {
    this.router.navigate(['/auth/register']);
  }

}