import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ISeminarios } from '../ISeminarios';
import { SeminarioService } from '../seminario.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-seminarios-form',
  templateUrl: './seminarios-form.component.html',
  styleUrls: ['./seminarios-form.component.css']
})
export class SeminariosFormComponent implements OnInit {

  modoEdicion: boolean = false;
  formGroup: FormGroup;
  SeminarioId: number;

  constructor(private fb: FormBuilder, private SeminarioService: SeminarioService,
    private router: Router, private activateddRoute: ActivatedRoute) {
    this.activateddRoute.params.subscribe(
      params => {

        this.SeminarioId = params['id'];
        console.log(this.SeminarioId);
        if (isNaN(this.SeminarioId)) {
          return;
        }
        else {
          this.modoEdicion = true;
          this.SeminarioService.getSeminarioesById(this.SeminarioId).subscribe(seminario =>
            this.cargarFormulario(seminario), error => this.router.navigate(["/seminarios"])
          );
        }

      }

    )
  }

  ngOnInit() {
    this.formGroup = this.fb.group({
      descripcion: '',
      duracion: '',
      precio: ''
    })
  }

  save() {
    let seminario: ISeminarios = Object.assign({}, this.formGroup.value);
    if (this.modoEdicion == true) {
      seminario.id = +this.SeminarioId;
      this.SeminarioService.actualizarSeminario(seminario)
        .subscribe(seminario => this.InsertoOK(), error => console.error(error));
    }
    else {

      this.SeminarioService.crearSeminario(seminario)
        .subscribe(seminario => this.InsertoOK(), error => console.error(error));
    }

  }

  InsertoOK() {
    console.table("INSERTO OK");
    this.router.navigate(["/seminarios"]);
  }

  cargarFormulario(seminario: ISeminarios) {
    this.formGroup.patchValue({
      descripcion: seminario.descripcion,
      duracion: seminario.duracion,
      precio: seminario.precio

    })
  }
}
