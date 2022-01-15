import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { RetornoServidor } from '../Models/RetornoServidor.Model';

@Injectable({
  providedIn: 'root'
})
export class ServicioPedidos {

  BaseUrl: string = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseUrl = baseUrl;
  }

  ObtenerPedidosPorUsuarioID(usuarioID: number): any{
    console.log(this.BaseUrl + `api/Pedidos/${usuarioID}`);
    return this.http.get(this.BaseUrl + `api/Pedidos/${usuarioID}`);
  }
}
