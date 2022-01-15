export class LoginModel{
  constructor(usuario: string, contrasena: string) {
    this.Usuario = usuario;
    this.Contrasena = contrasena;
  }
  Usuario: string;
  Contrasena: string;
}
