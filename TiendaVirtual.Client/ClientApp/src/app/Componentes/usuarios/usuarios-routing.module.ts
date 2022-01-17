import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuariosComponent } from './usuarios.component';
import { PedidosUsuariosComponent } from './pedidos-usuarios/pedidos-usuarios.component';
import { CuentasUsuariosComponent } from './cuentas-usuarios/cuentas-usuarios.component';
import { FormasPagosUsuariosComponent } from './formas-pagos-usuarios/formas-pagos-usuarios.component';
import { MensajesUsuariosComponent } from './mensajes-usuarios/mensajes-usuarios.component';
import { ProteccionRutaPorRolesGuard } from '../../Guardianes/proteccion-ruta-por-role.guard';

const routes: Routes = [
  {
    path: '',
    component: UsuariosComponent,
    children: [

      { path: 'Pedidos', component: PedidosUsuariosComponent },
      { path: 'Cuentas', component: CuentasUsuariosComponent, canActivate: [ProteccionRutaPorRolesGuard], data: { rol: 1, redirecTo: 'Principal' }  },
      { path: 'FormasPagos', component: FormasPagosUsuariosComponent, canActivate: [ProteccionRutaPorRolesGuard], data: { rol: 1, redirecTo: 'Principal' } },
      { path: 'Mensajes', component: MensajesUsuariosComponent },
      { path: '', redirectTo: 'Pedidos', pathMatch:'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuariosRoutingModule { }
