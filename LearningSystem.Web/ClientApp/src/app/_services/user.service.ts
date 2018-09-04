import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User, UserDetail } from '../_models';
import { environment } from '../../environments/environment';
import { Feedback } from '../_models/feedback';

@Injectable()
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
      return this.http.get<User[]>(`${environment.apiBaseUrl}/users`);
    }

    getById(id: number) {
      return this.http.get(`${environment.apiBaseUrl}/users/` + id);
    }

    getByUsername(username: string) {
      return this.http.get<UserDetail>(`${environment.apiBaseUrl}/users/get/` + username);
    }

    register(user: User) {
      return this.http.post(`${environment.apiBaseUrl}/users/register`, user);
    }

    update(user: User) {
      return this.http.put(`${environment.apiBaseUrl}/users/` + user.id, user);
    }

    delete(id: number) {
      return this.http.delete(`${environment.apiBaseUrl}/users/` + id);
    }

    sendFeedback(feedback: Feedback) {
      return this.http.post<Feedback>(`${environment.apiBaseUrl}/users/feedback`, feedback);
    }
}
