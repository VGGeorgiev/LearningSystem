import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Season } from '../_models';
import { environment } from '../../environments/environment';

@Injectable()
export class SeasonService {
  constructor(private http: HttpClient) { }

  GetAvailable() {
    return this.http.get<Season[]>(`${environment.apiBaseUrl}/seasons/available`);
  }

  GetById(id: number) {
    return this.http.get<Season>(`${environment.apiBaseUrl}/seasons/get/${id}`);
  }
}
