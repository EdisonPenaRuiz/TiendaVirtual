import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { RetornoServidor } from '../../../Interfaces/RespuestaGenericasServidorInterface/RetornoServidor.Interface';
import { FormasPagosUsuariosModel } from '../../../Models/FormasPagosModel/FormasPagosUsuarios.Model';
import { ServicioFormasPagosUsuarios } from '../../../Servicios/servicio-formas-pagos-usuarios.service';
import { ServicioLocalStorage } from '../../../Servicios/servicio-local-storage.service';

@Component({
  selector: 'app-formas-pagos-usuarios',
  templateUrl: './formas-pagos-usuarios.component.html',
  styleUrls: ['./formas-pagos-usuarios.component.css']
})
export class FormasPagosUsuariosComponent implements OnInit {

  FormasDePagos: FormasPagosUsuariosModel[] = [];
  NombreComprador: string = "";
  ApellidoComprador: string = "";

  constructor(private ServicioFormasPagosUsuario: ServicioFormasPagosUsuarios, private servicioLocalStorage: ServicioLocalStorage) { }

  ngOnInit(): void {
    this.ObtenerFormaPagosUsuarioLogueado();
  }

  ObtenerFormaPagosUsuarioLogueado() {
    var usuario = this.servicioLocalStorage.ObteniendoCredencialesLocalStorage();

    //Datos comprador
    this.NombreComprador = usuario['nombre'];
    this.ApellidoComprador = usuario['apellido'];

    //Obteniendo pedidos de comprador
    this.ServicioFormasPagosUsuario.ObtenerFormasPagosPorUsuarioID(usuario['usuarioId']).subscribe((resp: RetornoServidor<FormasPagosUsuariosModel>) => {
      console.log(resp);
      if (resp.operacionExitosa == true && resp.error == null) {
        console.log(resp.listadoResultados)
        if (resp.listadoResultados.length > 0) {
          this.FormasDePagos = resp.listadoResultados;
        }
      } else if (resp.operacionExitosa == true && resp.error != null) {
        this.FormasDePagos = [];
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
