import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProteccionRutaPorRolesGuard } from '../Guards/proteccion-ruta-por-role.guard';
import { ComponentePrincipalComponent } from './componente-principal.component';
import { CompradorComponent } from './comprador/comprador.component';

const routes: Routes = [
  {
    path: '',
    component: ComponentePrincipalComponent,
    children: [
      //Roles 1:Comprador 2:Vendedor
      { path: 'Comprador', component: CompradorComponent, canActivate: [ProteccionRutaPorRolesGuard], data: { rol: 1,redirecTo:'Principal' }, loadChildren: () => import('./comprador/comprador.module').then(m => m.CompradorModule) },
      
    ]
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentePrincipalRoutingModule { }
