import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CardPedidosCompradorComponent } from './card-pedidos-usuarios/card-pedidos-usuarios.component';
import { CardCuentasUsuariosComponent } from './card-cuentas-usuarios/card-cuentas-usuarios.component';
import { UsuariosComponent } from './usuarios.component';
import { PedidosUsuariosComponent } from './pedidos-usuarios/pedidos-usuarios.component';
import { CuentasUsuariosComponent } from './cuentas-usuarios/cuentas-usuarios.component';
import { FormasPagosUsuariosComponent } from './formas-pagos-usuarios/formas-pagos-usuarios.component';
import { MensajesUsuariosComponent } from './mensajes-usuarios/mensajes-usuarios.component';
import { UsuariosRoutingModule } from './usuarios-routing.module';


@NgModule({
  declarations: [
    UsuariosComponent,
    PedidosUsuariosComponent,
    CuentasUsuariosComponent,
    FormasPagosUsuariosComponent,
    MensajesUsuariosComponent,
    CardPedidosCompradorComponent,
    CardCuentasUsuariosComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule
  ]
})
export class UsuariosModule { }
