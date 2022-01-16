export class CuentasModel{
  constructor(CuentaID: number, Balance: number, UsuarioID: number, NumeroTarjeta: string) {
    this.cuentaId = CuentaID;
    this.balance = Balance;
    this.usuarioId = UsuarioID;
    this.numeroTarjerta = NumeroTarjeta;
  }

  cuentaId: number;
  balance: number;
  usuarioId: number;
  numeroTarjerta: string;
}
