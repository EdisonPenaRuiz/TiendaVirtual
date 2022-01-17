import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComponentePrincipalRoutingModule } from './componente-principal-routing.module';
import { ComponentePrincipal } from './componente-principal.component';
import { NgxPermissionsModule, NgxPermissionsService } from 'ngx-permissions'
import { CargarPermisosService } from '../Servicios/cargar-permisos.service';
import { UsuariosModule } from './usuarios/usuarios.module';
import { NavMenuComponent } from '../Componentes-Compartidos/nav-menu/nav-menu.component';
import { HeadComponent } from '../Componentes-Compartidos/head/head.component';

@NgModule({
  declarations: [
    ComponentePrincipal,
    NavMenuComponent,
    HeadComponent
  ],
  imports: [
    CommonModule,
    ComponentePrincipalRoutingModule,
    NgxPermissionsModule.forChild(),
    UsuariosModule
   
    
  ]
})
export class ComponentePrincipalModule { }
