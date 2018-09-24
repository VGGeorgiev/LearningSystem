import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User, UserInput, UserInCourse } from '../_models';
import { environment } from '../../environments/environment';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<User[]>(`${environment.apiBaseUrl}/users`);
  }

  getById(id: number) {
    return this.http.get<User>(`${environment.apiBaseUrl}/users/` + id);
  }

  getByUsername(username: string) {
    return this.http.get<User>(`${environment.apiBaseUrl}/users/get/` + username);
  }

  register(user: User) {
    return this.http.post(`${environment.apiBaseUrl}/users/register`, user);
  }

  update(user: User) {
    return this.http.put(`${environment.apiBaseUrl}/users/` + user.id, user);
  }

  updateType(user: UserInput) {
    return this.http.put(`${environment.apiBaseUrl}/users/` + user.id, user);
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiBaseUrl}/users/` + id);
  }
  
  getUserInCourses(userId: number) {
    return this.http.get<UserInCourse[]>(`${environment.apiBaseUrl}/StudentsInCourse/get/` + userId);
  }

  changeGrade(userInCourse: UserInCourse) {
    return this.http.post(`${environment.apiBaseUrl}/StudentsInCourse/changeGrade/`, userInCourse);
  }
}
