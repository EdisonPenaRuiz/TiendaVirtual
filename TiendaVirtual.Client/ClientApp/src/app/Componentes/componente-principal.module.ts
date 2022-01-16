import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComponentePrincipalRoutingModule } from './componente-principal-routing.module';
import { ComponentePrincipalComponent } from './componente-principal.component';
import { NavMenuComponent } from '../Compartidas/nav-menu/nav-menu.component';
import { HeadComponent } from '../Compartidas/head/head.component';


@NgModule({
  declarations: [
    ComponentePrincipalComponent,
    NavMenuComponent,
    HeadComponent
  ],
  imports: [
    CommonModule,
    ComponentePrincipalRoutingModule
  ]
})
export class ComponentePrincipalModule { }
