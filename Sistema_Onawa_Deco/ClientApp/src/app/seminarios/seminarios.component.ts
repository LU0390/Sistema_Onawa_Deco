import { Component, OnInit } from '@angular/core';
import { ISeminarios } from './ISeminarios';

@Component({
  selector: 'app-seminarios',
  templateUrl: './seminarios.component.html',
  styleUrls: ['./seminarios.component.css']
})
export class SeminariosComponent implements OnInit {
  ListadoSeminarios: ISeminarios[];
  constructor() { }

  ngOnInit() {
  }

}
