import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SeminariosComponent } from './seminarios/seminarios.component';
import { ProfesoresComponent } from './profesores/profesores.component';
import { SociosComponent } from './socios/socios.component';
import { SeminariosSociosComponent } from './seminarios-socios/seminarios-socios.component';
import { ProfesoresSeminariosComponent } from './profesores-seminarios/profesores-seminarios.component';
import { SocioService } from './socios/socio.service';
import { ProfesorService } from './profesores/profesor.service';
import { ProfesoresSeminariosService } from './profesores-seminarios/profesores-seminarios.service';
import { SeminarioService } from './seminarios/seminario.service';
import { SeminariosSociosService } from './seminarios-socios/seminarios-socios.service';
import { SociosFormComponent } from './socios/socios-form/socios-form.component';
import { SociosSeminariosComponent } from './socios/socios-seminarios/socios-seminarios.component';
import { ProfesoresFormComponent } from './profesores/profesores-form/profesores-form.component';
import { ProfesoresSeminariosFormComponent } from './profesores/profesores-seminarios-form/profesores-seminarios-form.component';
import { SeminariosFormComponent } from './seminarios/seminarios-form/seminarios-form.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SeminariosComponent,
    ProfesoresComponent,
    SociosComponent,
    SeminariosSociosComponent,
    ProfesoresSeminariosComponent,
    SociosFormComponent,
    SociosSeminariosComponent,
    ProfesoresFormComponent,
    ProfesoresSeminariosFormComponent,
    SeminariosFormComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'socios', component: SociosComponent },
      { path: 'seminarios', component: SeminariosComponent },
      { path: 'profesores', component: ProfesoresComponent },

      
      { path: 'socios-editar/:id', component: SociosFormComponent },
      { path: 'seminarios-editar/:id', component: SeminariosFormComponent },
      { path: 'profesores-editar/:dni', component: ProfesoresFormComponent },

      { path: 'socios-seminarios/:id', component: SociosSeminariosComponent },
      { path: 'profesores-seminarios/:id', component: ProfesoresSeminariosFormComponent },

      { path: 'socios-agregar', component: SociosFormComponent },
      { path: 'seminarios-agregar', component: SeminariosFormComponent },
      { path: 'profesores-agregar', component: ProfesoresFormComponent },

    ])
  ],
  providers: [SocioService, SeminarioService, ProfesorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
