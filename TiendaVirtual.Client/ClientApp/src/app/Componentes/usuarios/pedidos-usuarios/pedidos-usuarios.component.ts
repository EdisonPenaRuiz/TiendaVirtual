import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { RetornoServidor } from '../../../Interfaces/RespuestaGenericasServidorInterface/RetornoServidor.Interface';
import { PedidosUsuarios } from '../../../Models/PedidosModel/PedidosModel';
import { ServicioLocalStorage } from '../../../Servicios/servicio-local-storage.service';
import { ServicioPedidos } from '../../../Servicios/servicio-pedidos.service';

@Component({
  selector: 'app-pedidos-usuarios',
  templateUrl: './pedidos-usuarios.component.html',
  styleUrls: ['./pedidos-usuarios.component.css']
})
export class PedidosUsuariosComponent implements OnInit {

  constructor(private servicioPedidos: ServicioPedidos, private servicioLocalStorage: ServicioLocalStorage) { }

  Pedidos: PedidosUsuarios[] = [];
  NombreComprador: string = "";
  ApellidoComprador: string = "";

  ngOnInit(): void {
    this.ObtenerPedidosUsuarioLogueado();
  }

  ObtenerPedidosUsuarioLogueado() {
    var usuario = this.servicioLocalStorage.ObteniendoCredencialesLocalStorage();

    //Datos comprador
    this.NombreComprador = usuario['nombre'];
    this.ApellidoComprador = usuario['apellido'];

    //Obteniendo pedidos de comprador
    this.servicioPedidos.ObtenerPedidosPorUsuarioID(usuario['usuarioId']).subscribe((resp: RetornoServidor<PedidosUsuarios>) => {
      console.log(resp);
      if (resp.operacionExitosa == true && resp.error == null) {
        console.log(resp.listadoResultados)
        if (resp.listadoResultados.length > 0) {
          this.Pedidos = resp.listadoResultados;
        }
      } else if (resp.operacionExitosa == true && resp.error != null) {
        this.Pedidos = [];
      }
    },
      (error: any) => {
        Swal.fire({
          icon: 'error',
          title: 'Ha ocurrido un error',
          text: error.status == 404 ? 'No se encontro el servidor' : error.error
        })
      });
  }

}
