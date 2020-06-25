import { Component, OnInit } from '@angular/core';
import { ISeminarios } from './ISeminarios';
import { SeminarioService } from './seminario.service'

@Component({
  selector: 'app-seminarios',
  templateUrl: './seminarios.component.html',
  styleUrls: ['./seminarios.component.css']
})
export class SeminariosComponent implements OnInit {
  ListadoSeminarios: ISeminarios[];
  constructor(private SeminarioService: SeminarioService) { }

  ngOnInit() {
    this.cargarSeminario();
  }

  cargarSeminario() {
    this.SeminarioService.getSeminarios()
      .subscribe(seminariosDesdeApi => this.ListadoSeminarios= seminariosDesdeApi,
        error => console.error(error));
  }

  eliminarSeminario(seminario: ISeminarios) {
    this.SeminarioService.borrarSeminario(seminario.id)
      .subscribe(seminario => this.cargarSeminario());
  }


}
