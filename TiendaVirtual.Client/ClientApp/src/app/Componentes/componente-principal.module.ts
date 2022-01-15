import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComponentePrincipalRoutingModule } from './componente-principal-routing.module';
import { ComponentePrincipalComponent } from './componente-principal.component';
import { NavMenuComponent } from '../Compartidas/nav-menu/nav-menu.component';


@NgModule({
  declarations: [
    ComponentePrincipalComponent,
    NavMenuComponent
  ],
  imports: [
    CommonModule,
    ComponentePrincipalRoutingModule
  ]
})
export class ComponentePrincipalModule { }
