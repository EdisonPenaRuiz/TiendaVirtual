import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuariosModel } from '../Models/UsuarioModel/UsuarioModel';

@Injectable({
  providedIn: 'root'
})
export class ServicioUsuarios {
  UrlBase: string = "";
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.UrlBase = baseUrl;
  }

  AgregarUsuario(Usuario: UsuariosModel): Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(this.UrlBase + 'api/Usuarios', Usuario, { headers: headers });
  }
}
