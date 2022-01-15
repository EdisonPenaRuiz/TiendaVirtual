import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComponentePrincipalComponent } from './componente-principal.component';

const routes: Routes = [
  {
    path: '',
    component: ComponentePrincipalComponent,
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentePrincipalRoutingModule { }
