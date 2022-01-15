import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-pedidos-comprador',
  templateUrl: './card-pedidos-comprador.component.html',
  styleUrls: ['./card-pedidos-comprador.component.css']
})
export class CardPedidosCompradorComponent implements OnInit {

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
