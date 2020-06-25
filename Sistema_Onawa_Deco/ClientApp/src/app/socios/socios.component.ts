import { Component, OnInit } from '@angular/core';
import { ISocios } from './Isocios';
import {SocioService } from './socio.service'

@Component({
  selector: 'app-socios',
  templateUrl: './socios.component.html',
  styleUrls: ['./socios.component.css']
})
export class SociosComponent implements OnInit {

  ListadoSocios: ISocios[];
  constructor(private SocioService: SocioService) { }

  ngOnInit() {
    this.cargarSocios();
  }
  
  cargarSocios() {
    this.SocioService.getSocios()
      .subscribe(sociosDesdeApi => this.ListadoSocios = sociosDesdeApi,
        error => console.error(error));
  }

  eliminarSocio(socio: ISocios) {
    this.SocioService.borrarSocio(socio.id)
      .subscribe(socio => this.cargarSocios())
      ;
  }


}
