export class FormasPagosUsuariosModel{
  constructor(formaPagoID: number, nombreFormaPago: string, usuarioID: number) {
    this.formaPagoId = formaPagoID;
    this.nombre = nombreFormaPago;
    this.usuarioId = usuarioID;
  }

  formaPagoId: number;
  nombre: string;
  usuarioId: number;

}
