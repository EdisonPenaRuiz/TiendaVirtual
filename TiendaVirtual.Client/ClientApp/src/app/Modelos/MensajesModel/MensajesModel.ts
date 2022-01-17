export class MensajesModel{

  constructor(MensajeID: number, Mensaje: string, UsuarioIDDestino: number, UsuarioIDOrigen: number, PedidoID: number, EstadoMensaje: boolean) {
    this.MensajeId = MensajeID,
      this.Mensaje1 = Mensaje,
      this.UsuarioIdDestino = UsuarioIDDestino,
      this.UsuarioIdOrigen = UsuarioIDOrigen,
      this.PedidoId = PedidoID,
      this.EstadoMensaje = EstadoMensaje
  }

  MensajeId: number;
  Mensaje1: string;
  UsuarioIdDestino: number;
  UsuarioIdOrigen: number;
  PedidoId: number;
  EstadoMensaje: boolean;
}
