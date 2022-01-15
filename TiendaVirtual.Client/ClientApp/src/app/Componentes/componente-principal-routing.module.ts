import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComponentePrincipalComponent } from './componente-principal.component';
import { CompradorComponent } from './comprador/comprador.component';

const routes: Routes = [
  {
    path: '',
    component: ComponentePrincipalComponent,
    children: [
      { path: 'Comprador', component: CompradorComponent, loadChildren: () => import('./comprador/comprador.module').then(m => m.CompradorModule) },
      
    ]
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentePrincipalRoutingModule { }
