import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { UsuariosModel } from '../Models/UsuarioModel';

@Injectable({
  providedIn: 'root'
})
export class ServicioUsuarios {
  UrlBase: string = "";
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.UrlBase = baseUrl;
  }

  AgregarUsuario(Usuario: UsuariosModel) {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(this.UrlBase + 'api/Usuarios', Usuario, { headers: headers });
  }
}
