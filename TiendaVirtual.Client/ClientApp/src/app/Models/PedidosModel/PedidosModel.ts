export class PedidosModel {
  constructor(pedidoId: number, paisDestino: string, provinciaDestino: string, sectorDestino: string, articuloID: number, formaPagoID: number, usuarioID: number) {
    this.PedidoId = pedidoId;
    this.ArticuloId = articuloID;
    this.PaisDestino = paisDestino;
    this.ProvinciaDestino = provinciaDestino;
    this.SectorDestino = sectorDestino;
    this.FormaPagoId = formaPagoID;
    this.UsuarioId = usuarioID;
  }

  PedidoId: number;
  PaisDestino: string;
  ProvinciaDestino: string;
  SectorDestino: string;
  ArticuloId: number;
  FormaPagoId: number;
  UsuarioId: number;
}

export interface PedidosUsuarios {

  pedidoID: number;
  paisDestino: string;
  provinciaDestino: string;
  sectorDestino: string;
  formaDePago: string;
  precio: number;
  nombre: string;
}
