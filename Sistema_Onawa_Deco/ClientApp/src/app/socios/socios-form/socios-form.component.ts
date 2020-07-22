import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ISocios } from '../ISocios';
import { SocioService } from '../socio.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-socios-form',
  templateUrl: './socios-form.component.html',
  styleUrls: ['./socios-form.component.css'],
  providers: [DatePipe]
})
export class SociosFormComponent implements OnInit {

  modoEdicion: boolean = false;
  formGroup: FormGroup;
  socioId: number;

  constructor(private fb: FormBuilder, private SocioService: SocioService,
    private router: Router, private activateddRoute: ActivatedRoute,
    private datePipe: DatePipe) {
    this.activateddRoute.params.subscribe(
      params => {

        this.socioId = params['id'];
        console.log(this.socioId);
        if (isNaN(this.socioId)) {
          return;
        }
        else {
          this.modoEdicion = true;
          this.SocioService.getSociosById(this.socioId).subscribe(socio =>
            this.cargarFormulario(socio), error => this.router.navigate(["/socios"])
          );
        }

      }

    )
  }

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: '',
      telefonoContacto: '',
      fechaNacimiento: ''
    })
  }

  save() {
    let socio: ISocios = Object.assign({}, this.formGroup.value);
    if (this.modoEdicion == true) {
      socio.id = +this.socioId;
      socio.fechaNacimiento = new Date(socio.fechaNacimiento);
      this.SocioService.actualizarSocio(socio)
        .subscribe(socio => this.InsertoOK(), error => console.error(error));
    }
    else {
      //socio.id = +this.socioId;
      this.SocioService.crearSocio(socio)
        .subscribe(socio => this.InsertoOK(), error => console.error(error));
    }

  }

  InsertoOK() {
    console.table("INSERTO OK");
    this.router.navigate(["/socios"]);
  }

  cargarFormulario(socio: ISocios) {
    this.formGroup.patchValue({
      nombre: socio.nombre,
      telefonoContacto: socio.telefonoContacto,
      fechaNacimiento: this.datePipe.transform(socio.fechaNacimiento, 'yyyy-MM-dd'),
    })
  }
}




