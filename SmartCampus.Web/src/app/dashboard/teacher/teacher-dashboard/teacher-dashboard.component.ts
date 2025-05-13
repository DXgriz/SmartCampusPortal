import { Component } from '@angular/core';

@Component({
  selector: 'app-lecturer-dashboard',
  templateUrl: './teacher-dashboard.component.html',
  styleUrls: ['./teacher-dashboard.component.css']
})
export class TeacherDashboardComponent {
  teacherName = 'Prof. Smith';
  classesToday = ['Software Engineering - 09:00 AM', 'AI Principles - 11:00 AM'];
  reportedIssues = [
    { title: 'Projector not working', date: '2025-05-13' },
    { title: 'Wi-Fi downtime', date: '2025-05-12' }
  ];
}