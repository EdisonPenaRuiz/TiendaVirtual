import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccesosComponent } from './accesos.component';
import { LoginComponent } from './login/login.component';
import { RegistroUsuarioComponent } from './registro-usuario/registro-usuario.component';

const routes: Routes = [
  {
    path: '', component: AccesosComponent, children: [
      { path: 'login', component: LoginComponent },
      { path: 'registrar', component: RegistroUsuarioComponent },
      { path: '', redirectTo: 'login', pathMatch:'full' }
    ]
  }  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccesosRoutingModule { }
