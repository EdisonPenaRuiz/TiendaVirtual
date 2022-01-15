import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompradorComponent } from './comprador.component';
import { CuentasCompradorComponent } from './cuentas-comprador/cuentas-comprador.component';
import { FormasPagosCompradorComponent } from './formas-pagos-comprador/formas-pagos-comprador.component';
import { MensajesCompradorComponent } from './mensajes-comprador/mensajes-comprador.component';
import { PedidosCompradorComponent } from './pedidos-comprador/pedidos-comprador.component';

const routes: Routes = [
  {
    path: '',
    component: CompradorComponent,
    children: [
      
      { path: 'Pedidos', component: PedidosCompradorComponent },
      { path: 'Cuentas', component: CuentasCompradorComponent },
      { path: 'FormasPagos', component: FormasPagosCompradorComponent },
      { path: 'Mensajes', component: MensajesCompradorComponent },
      { path: '', redirectTo: 'Pedidos', pathMatch:'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompradorRoutingModule { }
