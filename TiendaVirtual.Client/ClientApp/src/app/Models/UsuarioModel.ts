export class UsuariosModel {

  constructor(nombre: string, apellido: string, usuario: string, contrasena: string,rolID:number) {

    this.NombreUsuario = usuario;
    this.Apellido = apellido;
    this.Nombre = nombre;
    this.Contrasena = contrasena;
    this.RolID = rolID;
  }

  NombreUsuario: string;
  Apellido: string;
  Nombre: string;
  Contrasena: string;
  RolID: number;
}
