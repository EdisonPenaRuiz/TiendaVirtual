import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NgxPermissionsModule, NgxPermissionsService } from 'ngx-permissions';
import { CargarPermisosService } from './Servicios/cargar-permisos.service';
import { ProteccionRutaAutenticacionGuard } from './Guardianes/proteccion-ruta-autenticacion.guard';

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
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxPermissionsModule.forRoot(),
    RouterModule.forRoot([
      
      { path: 'Acceso', loadChildren: () => import('./Accesos/accesos.module').then(m => m.AccesosModule) },
      {
        path: 'Principal', canActivate: [ProteccionRutaAutenticacionGuard], data: { rol: '1' }, loadChildren: () => import('./Componentes/componente-principal.module').then(m => m.ComponentePrincipalModule)
      }
      ,
      { path: '', redirectTo: 'Acceso', pathMatch: "prefix", }
      
    ])
  ],
  exports: [],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: permissionsFactory,
      deps: [NgxPermissionsService, CargarPermisosService], multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
