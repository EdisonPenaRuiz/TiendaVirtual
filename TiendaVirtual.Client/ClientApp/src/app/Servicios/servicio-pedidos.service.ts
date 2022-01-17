import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { UsuariosModel } from '../Modelos/UsuarioModel/UsuarioModel';

@Injectable({
  providedIn: 'root'
})
export class ServicioPedidos {

  BaseUrl: string = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseUrl = baseUrl;
  }

  ObtenerPedidosPorUsuarioID(usuario: UsuariosModel): any{
    const headers = new HttpHeaders();
    usuario.contrasena = 'Contrasena falsa';
    usuario.nombreUsuario = 'Contrasena falsa';

    headers.append('Content-Type', 'application/json');
    return this.http.post(this.BaseUrl + `api/Pedidos/ObtenerPedidosPorUsuario`, usuario, { headers: headers });
  }
}
