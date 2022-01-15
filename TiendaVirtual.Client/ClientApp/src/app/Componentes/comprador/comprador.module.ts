import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompradorRoutingModule } from './comprador-routing.module';
import { CompradorComponent } from './comprador.component';
import { PedidosCompradorComponent } from './pedidos-comprador/pedidos-comprador.component';
import { CuentasCompradorComponent } from './cuentas-comprador/cuentas-comprador.component';
import { FormasPagosCompradorComponent } from './formas-pagos-comprador/formas-pagos-comprador.component';
import { MensajesCompradorComponent } from './mensajes-comprador/mensajes-comprador.component';
import { CardPedidosCompradorComponent } from './card-pedidos-comprador/card-pedidos-comprador.component';


@NgModule({
  declarations: [
    CompradorComponent,
    PedidosCompradorComponent,
    CuentasCompradorComponent,
    FormasPagosCompradorComponent,
    MensajesCompradorComponent,
    CardPedidosCompradorComponent
  ],
  imports: [
    CommonModule,
    CompradorRoutingModule
  ]
})
export class CompradorModule { }
