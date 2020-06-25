import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISeminarios } from './ISeminarios';


@Injectable({
  providedIn: 'root'
})
export class SeminarioService {

  private apiURL = this.baseUrl + 'api/seminarios';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl:
    string) { }

  get(): Observable<ISeminarios[]> {
    return this.http.get<ISeminarios[]>(this.apiURL);
  }

  getSeminarioesSocio(SocioDni: number): Observable<ISeminarios[]> {
    return this.http.get<ISeminarios[]>(this.apiURL + '/inscripciones/' + SocioDni)
  }

  getSeminarioesById(SeminarioId: number): Observable<ISeminarios> {
    return this.http.get<ISeminarios>(this.apiURL + '/' + SeminarioId)
  }

  crearSeminario(Seminario: ISeminarios): Observable<ISeminarios> {
    return this.http.post<ISeminarios>(this.apiURL, Seminario);
  }

  actualizarSeminario(seminario: ISeminarios): Observable<ISeminarios> {

    if (isNaN(seminario.Id)) {
      console.log("NO ES NUMERICO");
    }
    seminario.Id = +seminario.Id;
    return this.http.put<ISeminarios>(this.apiURL + '/' + seminario.Id, seminario);
  }

  borrarSeminario(seminarioId: number): Observable<ISeminarios> {
    return this.http.delete<ISeminarios>(this.apiURL + '/' + seminarioId)
  }

}
