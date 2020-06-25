import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProfesores } from './IProfesores';
import { ISeminarios } from '../seminarios/ISeminarios'


@Injectable({
  providedIn: 'root'
})
export class ProfesorService {

  private apiURL = this.baseUrl + 'api/profesores';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl:
    string) { }

  getProfesores(): Observable<IProfesores[]> {
    return this.http.get<IProfesores[]>(this.apiURL);
  }

  getProfesorById(ProfesorDni: number): Observable<IProfesores> {
    return this.http.get<IProfesores>(this.apiURL + '/' + ProfesorDni)
  }

  crearProfesor(profesor: IProfesores): Observable<IProfesores> {
    return this.http.post<IProfesores>(this.apiURL, profesor);
  }

  actualizarProfesor(profesor: IProfesores): Observable<IProfesores> {
    
    return this.http.put<IProfesores>(this.apiURL + '/' + profesor.dni, profesor);
  }

  borrarProfesor(ProfesorDni: number): Observable<IProfesores> {
    return this.http.delete<IProfesores>(this.apiURL + '/' + ProfesorDni)
  }
  getInscripcionesProfesores(profesorDni: number): Observable<ISeminarios[]> {
    return this.http.get<ISeminarios[]>(this.apiURL + '/inscripciones/' + profesorDni);
  }


}
