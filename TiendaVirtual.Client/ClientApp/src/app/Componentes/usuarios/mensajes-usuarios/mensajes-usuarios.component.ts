import { Component, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { MensajesModel } from '../../../Modelos/MensajesModel/MensajesModel';
import { ServicioLocalStorage } from '../../../Servicios/servicio-local-storage.service';
import { ServicioMensajeria } from '../../../Servicios/servicio-mensajeria.service';

@Component({
  selector: 'app-mensajes-usuarios',
  templateUrl: './mensajes-usuarios.component.html',
  styleUrls: ['./mensajes-usuarios.component.css']
})
export class MensajesUsuariosComponent implements OnInit {

  Mensajes: MensajesModel[] = [];
  NombreComprador: string = "";
  ApellidoComprador: string = "";
  constructor(private servicioLocalStorage: ServicioLocalStorage) { }

  ngOnInit(): void {
    this.ObtenerPedidosUsuarioLogueado();
  }

  llamarSerrvice() {
    
    //this.ServicioMensajeria.EnviarMensajeUsuario();
  }

  ObtenerPedidosUsuarioLogueado() {
    var usuario = this.servicioLocalStorage.ObteniendoCredencialesLocalStorage();
    //Datos comprador
    this.NombreComprador = usuario.nombre;
    this.ApellidoComprador = usuario.apellido;
   
  }


  
}
