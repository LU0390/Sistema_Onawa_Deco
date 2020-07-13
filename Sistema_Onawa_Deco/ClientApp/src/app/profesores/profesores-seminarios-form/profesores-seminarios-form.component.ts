import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';  
import { IProfesores } from '../iprofesores'
import {ISeminarios } from '../../seminarios/ISeminarios';

import { ProfesorService } from '../profesor.service';
import { SeminarioService } from '../../seminarios/seminario.service'
import { ProfesoresSeminariosService } from '../../profesores-seminarios/profesores-seminarios.service'
import { IProfesoresSeminarios } from 'src/app/profesores-seminarios/IProfesores-seminarios';



@Component({
  selector: 'app-profesores-seminarios-form',
  templateUrl: './profesores-seminarios-form.component.html',
  styleUrls: ['./profesores-seminarios-form.component.css']
})
export class ProfesoresSeminariosFormComponent implements OnInit {

  ListadoSeminariosCombo: ISeminarios[];
  ListadoSeminariosDictados: ISeminarios[];
  ProfesorId: number;
  Profesor: IProfesores;
  SeminarioSeleccionado: number;

  constructor(private ProfesorService: ProfesorService,
    private SeminarioServicio: SeminarioService,
    private ProfesorSeminarioServicio: ProfesoresSeminariosService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    console.log("Constructor");
    this.activatedRoute.params.subscribe(

      params => {
        this.ProfesorId = params['id'];
        this.SeminarioSeleccionado = 0;
        this.cargarCabecera();


        if (isNaN(this.ProfesorId)) {
        }

      }
    );

  }

  ngOnInit() {
    this.cargarAsociaciones();
    this.cargarCombo();
  }

  cargarCabecera() {
    this.ProfesorService.getProfesorById(this.ProfesorId)
      .subscribe(profesoresDesdeApi => this.Profesor = profesoresDesdeApi,
        error => console.error(error));
  }

  cargarCombo() {
    this.SeminarioServicio.getSeminarios()
      .subscribe(seminariosDesdeApi => this.ListadoSeminariosCombo = seminariosDesdeApi,
        error => console.error(error));
  }

  cargarAsociaciones() {
    this.ProfesorSeminarioServicio.getInscripcionesProfesores(this.ProfesorId)
      .subscribe(semi => this.ListadoSeminariosDictados = semi,
        error => console.error(error));
  }

  cambioSeminarios(event) {
    this.SeminarioSeleccionado = event.target.value;

  }

  guardarAsociacion() {
    this.ProfesorSeminarioServicio.crearProfesorseminario(this.ProfesorId, this.SeminarioSeleccionado)
      .subscribe();
    this.cargarAsociaciones();
  }

  borrarAsociacion(SeminariosId: number) {
    this.SeminarioSeleccionado = SeminariosId;
    this.ProfesorSeminarioServicio.borrarProfesorseminario(this.ProfesorId, this.SeminarioSeleccionado)
      .subscribe();
    this.cargarAsociaciones();
  }



}
