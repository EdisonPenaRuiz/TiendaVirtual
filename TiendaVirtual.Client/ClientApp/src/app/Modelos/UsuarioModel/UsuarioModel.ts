export class UsuariosModel {

  constructor(nombre: string, apellido: string, usuario: string, contrasena: string,rolID:number,usuarioID:number) {

    this.nombreUsuario = usuario;
    this.apellido = apellido;
    this.nombre = nombre;
    this.contrasena = contrasena;
    this.rolId = rolID;
    this.usuarioId = usuarioID
  }

  nombreUsuario: string;
  apellido: string;
  nombre: string;
  contrasena: string;
  rolId: number;
  usuarioId: number
}
