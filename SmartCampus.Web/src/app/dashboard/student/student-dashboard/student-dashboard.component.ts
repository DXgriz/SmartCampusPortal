import { Component } from '@angular/core';

@Component({
  selector: 'app-student-dashboard',
  templateUrl: './student-dashboard.component.html',
  styleUrls: ['./student-dashboard.component.css']
})


export class StudentDashboardComponent {
  studentName = 'John Doe';
  upcomingClasses = [
    { subject: 'Mathematics', time: '10:00 AM' },
    { subject: 'Physics', time: '12:00 PM' }
  ];
  bookings = [
    { service: 'Study Room 1', date: '2025-05-14' },
    { service: 'Career Advisor', date: '2025-05-15' }
  ];
}