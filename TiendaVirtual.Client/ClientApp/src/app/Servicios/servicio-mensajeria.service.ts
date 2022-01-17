import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class ServicioMensajeria {
  UrlBase: string = "";

  _hubConneccion :HubConnection;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.UrlBase = baseUrl;
    let builder = new HubConnectionBuilder();
    this._hubConneccion = builder.withUrl("https://localhost:44363/MensajeriaTiempoReal").build();
    this._hubConneccion.start().then(data => {
      this._hubConneccion.invoke("EnviarMensaje").then(data => {
        () => {this._hubConneccion.on("Mensaje", (mensaje) => {
        alert(mensaje);
      });}
      }).catch(error => console.log(error));
    }).catch(error => console.log(error));
   
   
  }

  EnviarMensajeUsuario() {
    //La siguiente url va dinamica
    
    
  }

  ObtenerMensajesUsuarioDestino(usuarioDestinoId: number) {
    return this.httpClient.get(this.UrlBase + `api/Mensajeria/${usuarioDestinoId}`);
  }

  /*EnviarMensaje(mensajes: string) {
    console.log(mensajes);
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(this.UrlBase + `api/Mensajeria`, mensajes);
  }*/

}
