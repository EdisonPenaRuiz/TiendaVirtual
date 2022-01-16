import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServicioPedidos {

  BaseUrl: string = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseUrl = baseUrl;
  }

  ObtenerPedidosPorUsuarioID(usuarioID: number): any{
    return this.http.get(this.BaseUrl + `api/Pedidos/${usuarioID}`);
  }
}
