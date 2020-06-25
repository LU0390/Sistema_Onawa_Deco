import { Component, OnInit } from '@angular/core';
import { IProfesores } from './iprofesores';
import {ProfesorService } from './profesor.service'

@Component({
  selector: 'app-profesores',
  templateUrl: './profesores.component.html',
  styleUrls: ['./profesores.component.css']
})
export class ProfesoresComponent implements OnInit {

  ListadoProfesores: IProfesores[];
  constructor(private ProfesorService: ProfesorService) { }

  ngOnInit() {
    this.cargarProfesores();
  }

  cargarProfesores() {
    this.ProfesorService.getProfesores()
      .subscribe(ProfesoresDesdeApi => this.ListadoProfesores = ProfesoresDesdeApi,
        error => console.error(error));
  }

  eliminarProfesor(Profesor: IProfesores) {
    this.ProfesorService.borrarProfesor(Profesor.dni)
      .subscribe(Profesor => this.cargarProfesores())
      ;
  }

}
