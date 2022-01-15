import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './Compartidas/nav-menu/nav-menu.component';
import { CargandoComponent } from './Compartidas/CargandoGeneral/cargando.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      
      {path: 'Acceso', loadChildren: () => import('./Accesos/accesos.module').then(m => m.AccesosModule)},
      {path: 'Principal', loadChildren: () => import('./Componentes/componente-principal.module').then(m => m.ComponentePrincipalModule) }
      ,
      { path: '', redirectTo: 'Acceso', pathMatch: "prefix", }
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
