import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProteccionRutaAutenticacionGuard } from '../Guardianes/proteccion-ruta-autenticacion.guard';
import { ComponentePrincipal } from './componente-principal.component';
import { UsuariosComponent } from './usuarios/usuarios.component';

const routes: Routes = [
  {
    path: '',
    component: ComponentePrincipal,
    canActivate: [ProteccionRutaAutenticacionGuard],
    children: [
      { path: '', component: UsuariosComponent, loadChildren: () => import('./usuarios/usuarios.module').then(m => m.UsuariosModule) },
      
    ]
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentePrincipalRoutingModule { }
