import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuariosComponent } from './usuarios.component';
import { PedidosUsuariosComponent } from './pedidos-usuarios/pedidos-usuarios.component';
import { CuentasUsuariosComponent } from './cuentas-usuarios/cuentas-usuarios.component';
import { FormasPagosUsuariosComponent } from './formas-pagos-usuarios/formas-pagos-usuarios.component';
import { MensajesUsuariosComponent } from './mensajes-usuarios/mensajes-usuarios.component';
import { UsuariosRoutingModule } from './usuarios-routing.module';
import { TarjetaPedidosCompradorComponent } from './tarjeta-pedidos-usuarios/tarjeta-pedidos-usuarios.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { TarjetaCuentasUsuariosComponent } from './tarjeta-cuentas-usuarios/tarjeta-cuentas-usuarios.component';


@NgModule({
  declarations: [
    UsuariosComponent,
    PedidosUsuariosComponent,
    CuentasUsuariosComponent,
    FormasPagosUsuariosComponent,
    MensajesUsuariosComponent,
    TarjetaPedidosCompradorComponent,
    TarjetaCuentasUsuariosComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    NgxPermissionsModule.forChild(),
  ]
})
export class UsuariosModule { }
