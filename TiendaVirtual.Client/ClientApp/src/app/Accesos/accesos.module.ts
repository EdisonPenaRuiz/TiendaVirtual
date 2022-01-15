import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccesosRoutingModule } from './accesos-routing.module';
import { LoginComponent } from './login/login.component';
import { RegistroUsuarioComponent } from './registro-usuario/registro-usuario.component';
import { AccesosComponent } from './accesos.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CargandoComponent } from '../Compartidas/CargandoGeneral/cargando.component';


@NgModule({
  declarations: [LoginComponent, RegistroUsuarioComponent, AccesosComponent, CargandoComponent],
  imports: [
    CommonModule,
    AccesosRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class AccesosModule { }
