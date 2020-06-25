
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISocios } from './ISocios';
import { ISeminarios } from '../seminarios/ISeminarios'


@Injectable({
  providedIn: 'root'
})
export class SocioService {

  private apiURL = this.baseUrl + 'api/socios';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl:
    string) { }

  getSocios(): Observable<ISocios[]> {
    return this.http.get<ISocios[]>(this.apiURL);
  }

  getSociosById(SocioId: number): Observable<ISocios> {
    return this.http.get<ISocios>(this.apiURL + '/' + SocioId)
  }

  crearSocio(socio: ISocios): Observable<ISocios> {
    return this.http.post<ISocios>(this.apiURL, socio);
  }

  actualizarSocio(socio: ISocios): Observable<ISocios> {
    return this.http.put<ISocios>(this.apiURL + '/' + socio.id, socio);
  }

  borrarSocio(SocioId: number): Observable<ISocios> {
    return this.http.delete<ISocios>(this.apiURL + '/' + SocioId)
  }
  getInscripcionesSocio(SocioId: number): Observable<ISeminarios[]> {
    return this.http.get<ISeminarios[]>(this.apiURL + '/inscripciones/' + SocioId);
  }


}
