import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComponentePrincipal } from './componente-principal.component';
import { UsuariosComponent } from './usuarios/usuarios.component';

const routes: Routes = [
  {
    path: '',
    component: ComponentePrincipal,
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
