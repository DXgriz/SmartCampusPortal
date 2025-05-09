import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data['role'];
    const user = this.authService.getCurrentUser(); // Gets current user from token/localStorage

    if (!user) {
      // Not logged in
      this.router.navigate(['/login']);
      return false;
    }

    if (expectedRole && user.role !== expectedRole) {
      // Logged in but role mismatch
      this.router.navigate(['/login']);
      return false;
    }

    return true;
  }
}