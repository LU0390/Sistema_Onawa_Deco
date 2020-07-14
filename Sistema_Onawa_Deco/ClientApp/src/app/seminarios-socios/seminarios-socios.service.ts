import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISeminariosSocios } from './ISeminarios-socios';
import { ISeminarios } from '../seminarios/ISeminarios'

@Injectable({
  providedIn: 'root'
})
export class SeminariosSociosService {


  private apiURL = this.baseUrl + 'api/SeminariosSocios';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl:
    string) { }

  crearsocioseminario(socioId: number, SeminarioId: number): Observable<{}> {
    return this.http.post(this.apiURL + '?socioId=' + socioId + '&seminarioId=' + SeminarioId, null);
  }

  borrarsocioseminario(socioId: number, SeminarioId: number): Observable<{}> {
    return this.http.delete(this.apiURL + '?socioId=' + socioId + '&seminarioId=' + SeminarioId)
  }

  getInscripcionesSocios(SocioId: number): Observable<ISeminarios[]> {
    return this.http.get<ISeminarios[]>(this.apiURL + '/' + SocioId);
  }

}

