import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { CommonModule } from '@angular/common';
import { TimetableService, Timetable } from '../timetable.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-timetable-viewer',
  standalone: true,
  imports: [CommonModule,DatePipe],
  templateUrl: './timetable-viewer.component.html',
  styleUrls: ['./timetable-viewer.component.css']
})
export class TimetableViewerComponent implements OnInit {
  timetable: Timetable[] = [];
  studentId: number = 1;  
  errorMessage: string = '';
  loading: boolean = false;

  constructor(private timetableService: TimetableService, private route: ActivatedRoute) { 
    this.route.params.subscribe(params => {
      this.studentId = params['id'];
      this.loadTimetable();
    });
  }

  loadTimetable(): void {
    this.loading = true;
    this.getTimetable();
  }

  ngOnInit(): void {
    this.getTimetable();
  }

  getTimetable(): void {
    this.timetableService.getTimetableForStudent(this.studentId).subscribe(
      (data: Timetable[]) => {
        this.timetable = data;
      },
      (error: any) => {
        console.error('Error fetching timetable:', error);
      }
    );
  }
}