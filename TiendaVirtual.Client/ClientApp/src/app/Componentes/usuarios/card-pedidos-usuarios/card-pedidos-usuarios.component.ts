import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-pedidos-usuarios',
  templateUrl: './card-pedidos-usuarios.component.html',
  styleUrls: ['./card-pedidos-usuarios.component.css']
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
