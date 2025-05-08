import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Timetable {
  courseName: string;
  time: string;
  date: string;
  location: string;
  lecturer: string;
}

@Injectable({
  providedIn: 'root'
})
export class TimetableService {
  private apiUrl = 'https://api.smartcampus.com/timetables'; // Replace with actual API URL

  constructor(private http: HttpClient) { }

  getTimetableForStudent(studentId: number): Observable<Timetable[]> {
    return this.http.get<Timetable[]>(`${this.apiUrl}/student/${studentId}`);
  }
}