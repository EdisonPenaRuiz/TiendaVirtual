import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'tarjeta-pedidos-usuarios',
  templateUrl: './tarjeta-pedidos-usuarios.component.html',
  styleUrls: ['./tarjeta-pedidos-usuarios.component.css']
})
export class TarjetaPedidosCompradorComponent implements OnInit {

  constructor() { }

  @Input() PedidoId: number = 0;
  @Input() PaisDestino: string="";
  @Input() ProvinciaDestino: string="";
  @Input() SectorDestino: string="";
  @Input() FormaPago: string = "";
  @Input() Precio: number = 0;
  @Input() Articulo: string = "";

  ngOnInit(): void {
  }

}
