import { Routes } from '@angular/router';
import { HomeComponent } from './core/home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AdminDashboardComponent } from './dashboard/admin/admin-dashboard/admin-dashboard.component';
import { StudentDashboardComponent } from './dashboard/student/student-dashboard/student-dashboard.component';
import { TeacherDashboardComponent } from './dashboard/teacher/teacher-dashboard/teacher-dashboard.component';
import { AuthGuard } from './auth/auth.guard';
import { TimetableViewerComponent } from './student/timetable-viewer/timetable-viewer.component';


export const routes: Routes = [
  { path: '', component: HomeComponent },

  // Public routes
  { path: 'auth/login', component: LoginComponent },
  { path: 'auth/register', component: RegisterComponent },
  { path: '', component: HomeComponent },

  // Admin Routes
  {
    path: 'admin',
    component: AdminDashboardComponent,
    canActivate: [AuthGuard],
    data: { role: 'Administrator' }
  },
  {
    path: 'dashboard/admin',
    component: AdminDashboardComponent,
    canActivate: [AuthGuard]
  },

  // Student Routes
  {
    path: 'student',
    component: StudentDashboardComponent,
    canActivate: [AuthGuard],
    data: { role: 'Student' }
  },
  {
    path: 'dashboard/student',
    component: StudentDashboardComponent,
    canActivate: [AuthGuard]
  },

  // Teacher Routes
  {
    path: 'teacher',
    component: TeacherDashboardComponent,
    canActivate: [AuthGuard],
    data: { role: 'Teacher' }
  },
  {
    path: 'dashboard/teacher',
    component: TeacherDashboardComponent,
    canActivate: [AuthGuard]
  },
  //Timetable
  { path: 'student/timetable', 
    component: TimetableViewerComponent, 
    canActivate: [AuthGuard] },

  // Wildcard fallback route
  { path: '**', redirectTo: '' }
];
