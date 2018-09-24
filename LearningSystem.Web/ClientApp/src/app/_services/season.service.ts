import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Season, SeasonInput } from '../_models';
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

  GetAll() {
    return this.http.get<SeasonInput[]>(`${environment.apiBaseUrl}/seasons/get`);
  }

  sendSeason(season: SeasonInput) {
    return this.http.post<SeasonInput>(`${environment.apiBaseUrl}/seasons/insert`, season);
  }

  editSeason(id: number, season: SeasonInput) {
    return this.http.put<SeasonInput>(`${environment.apiBaseUrl}/seasons/edit/${id}`, season)
  }

  deleteSeason(id: number) {
    return this.http.delete(`${environment.apiBaseUrl}/seasons/delete/${id}`);
  }
}
