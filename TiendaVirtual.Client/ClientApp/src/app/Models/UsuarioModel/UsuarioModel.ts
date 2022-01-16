export class UsuariosModel {

  constructor(nombre: string, apellido: string, usuario: string, contrasena: string,rolID:number) {

    this.NombreUsuario = usuario;
    this.apellido = apellido;
    this.nombre = nombre;
    this.Contrasena = contrasena;
    this.RolID = rolID;
  }

  NombreUsuario: string;
  apellido: string;
  nombre: string;
  Contrasena: string;
  RolID: number;
}
