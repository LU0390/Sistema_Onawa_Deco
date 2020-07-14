import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ISocios } from '../ISocios'
import { ISeminarios } from '../../seminarios/ISeminarios';
import { SocioService } from '../socio.service';
import { SeminarioService } from '../../seminarios/seminario.service'
import { SeminariosSociosService } from '../../seminarios-socios/seminarios-socios.service'
import { ISeminariosSocios } from 'src/app/seminarios-socios/ISeminarios-socios';

@Component({
  selector: 'app-socios-seminarios',
  templateUrl: './socios-seminarios.component.html',
  styleUrls: ['./socios-seminarios.component.css']
})
export class SociosSeminariosComponent implements OnInit {
  ListadoSeminariosCombo: ISeminarios[];
  ListadoSeminariosRegistrados: ISeminarios[];
  SocioId: number;
  Socio: ISocios;
  SeminarioSeleccionado: number;


  constructor(private SocioService: SocioService,
    private SeminarioServicio: SeminarioService,
    private SocioSeminarioServicio: SeminariosSociosService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    console.log("Constructor");
    this.activatedRoute.params.subscribe(

      params => {
        this.SocioId = params['id'];
        this.SeminarioSeleccionado = 0;
        this.cargarCabecera();


        if (isNaN(this.SocioId)) {
        }

      }
    );

}

ngOnInit() {
  this.cargarAsociaciones();
  this.cargarCombo();
}

  cargarCabecera() {
    this.SocioService.getSociosById(this.SocioId)
      .subscribe(sociosDesdeApi => this.Socio = sociosDesdeApi,
      error => console.error(error));
}

cargarCombo() {
  this.SeminarioServicio.getSeminarios()
    .subscribe(seminariosDesdeApi => this.ListadoSeminariosCombo = seminariosDesdeApi,
      error => console.error(error));
}

  cargarAsociaciones() {
    this.SocioSeminarioServicio.getInscripcionesSocios(this.SocioId)
      .subscribe(semi => this.ListadoSeminariosRegistrados = semi,
      error => console.error(error));
}

cambioSeminarios(event) {
  this.SeminarioSeleccionado = event.target.value;

}

  guardarAsociacion() {
    this.SocioSeminarioServicio.crearsocioseminario(this.SocioId, this.SeminarioSeleccionado)
    .subscribe();
  this.cargarAsociaciones();
}

borrarAsociacion(SeminariosId: number) {
  this.SeminarioSeleccionado = SeminariosId;
  this.SocioSeminarioServicio.borrarsocioseminario(this.SocioId, this.SeminarioSeleccionado)
    .subscribe();

  this.cargarAsociaciones();
}

}
