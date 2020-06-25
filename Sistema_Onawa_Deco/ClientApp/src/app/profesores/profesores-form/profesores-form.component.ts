import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { IProfesores } from '../iprofesores';
import { ProfesorService } from '../profesor.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-profesores-form',
  templateUrl: './profesores-form.component.html',
  styleUrls: ['./profesores-form.component.css']
})
export class ProfesoresFormComponent implements OnInit {
  modoEdicion: boolean = false;
  formGroup: FormGroup;
  profesorDni: number;

  constructor(private fb: FormBuilder, private ProfesorService: ProfesorService,
    private router: Router, private activateddRoute: ActivatedRoute) {
    this.activateddRoute.params.subscribe(
      params => {

        this.profesorDni = params['dni'];
        console.log(this.profesorDni);
        if (isNaN(this.profesorDni)) {
          return;
        }
        else {
          this.modoEdicion = true;
          this.ProfesorService.getProfesorById(this.profesorDni).subscribe(profesor =>
            this.cargarFormulario(profesor), error => this.router.navigate(["/profesores"])
          );
        }

      }

    )
  }

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: '',
      apellido: '',
      mail:'',
      telefono: ''
    })
  }

  save() {
    let profesor: IProfesores = Object.assign({}, this.formGroup.value);

    if (this.modoEdicion == true) {
      profesor.dni = +this.profesorDni;
      this.ProfesorService.actualizarProfesor(profesor)
        .subscribe(profesor => this.InsertoOK(), error => console.error(error));
    }
    else {
      this.ProfesorService.crearProfesor(profesor)
        .subscribe(profesor => this.InsertoOK(), error => console.error(error));
    }

  }

  InsertoOK() {
    console.table("INSERTO OK");
    this.router.navigate(["/profesores"]);
  }

  cargarFormulario(profesor: IProfesores) {
    this.formGroup.patchValue({
      nombre: profesor.nombre,
      apellido: profesor.apellido,
      mail: profesor.mail,
      telefono: profesor.telefono

    })
  }

}
