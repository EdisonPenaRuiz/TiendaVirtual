import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComponentePrincipalRoutingModule } from './componente-principal-routing.module';
import { ComponentePrincipal } from './componente-principal.component';
import { NavMenuComponent } from '../Compartidas/nav-menu/nav-menu.component';
import { HeadComponent } from '../Compartidas/head/head.component';
import { NgxPermissionsModule, NgxPermissionsService } from 'ngx-permissions'
import { CargarPermisosService } from '../Servicios/cargar-permisos.service';
import { UsuariosModule } from './usuarios/usuarios.module';

export function permissionsFactory(ngxPermissionsService: NgxPermissionsService, loadCargaService: CargarPermisosService) {
  return () => {
    return loadCargaService.loadPermisos().then((data) => {
      ngxPermissionsService.loadPermissions(data);
      return true;
    })
  }
}
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
  , providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: permissionsFactory,
      deps: [NgxPermissionsService, CargarPermisosService], multi: true
    }
  ]
})
export class ComponentePrincipalModule { }
