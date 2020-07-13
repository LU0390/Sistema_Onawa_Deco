import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProfesoresSeminarios } from './IProfesores-seminarios';
import {ISeminarios } from '../seminarios/ISeminarios'

@Injectable({
  providedIn: 'root'
})
export class ProfesoresSeminariosService {


  private apiURL = this.baseUrl + 'api/ProfesoresSeminarios';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl:
    string) { }

  crearProfesorseminario(ProfesorId: number, SeminarioId: number): Observable<{}> {
    return this.http.post(this.apiURL + '?profesorId=' + ProfesorId + '&seminarioId=' + SeminarioId, null);
  }

  borrarProfesorseminario(ProfesorId: number, SeminarioId: number): Observable<{}> {
    return this.http.delete(this.apiURL + '?profesorId=' + ProfesorId + '&seminarioId=' + SeminarioId)
  }

  getInscripcionesProfesores(profesorDni: number): Observable<IProfesoresSeminarios[]> {
    return this.http.get<IProfesoresSeminarios[]>(this.apiURL + '?id=' + profesorDni);
  }

}
