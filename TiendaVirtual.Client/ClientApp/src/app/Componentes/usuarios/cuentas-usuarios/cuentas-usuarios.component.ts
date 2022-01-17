import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { RetornoServidor } from '../../../Interfaces/RespuestaGenericasServidorInterface/RetornoServidor.Interface';
import { CuentasModel } from '../../../Modelos/CuentasModel/Cuentas.Model';
import { UsuariosModel } from '../../../Modelos/UsuarioModel/UsuarioModel';

import { ServicioCuentas} from '../../../Servicios/servicio-cuentas.service';
import { ServicioLocalStorage } from '../../../Servicios/servicio-local-storage.service';

@Component({
  selector: 'app-cuentas-usuarios',
  templateUrl: './cuentas-usuarios.component.html',
  styleUrls: ['./cuentas-usuarios.component.css']
})
export class CuentasUsuariosComponent implements OnInit {

  Cuentas: CuentasModel[] = [];
  NombreComprador: string = "";
  ApellidoComprador: string = "";

  constructor(private ServicioCuentas: ServicioCuentas, private servicioLocalStorage: ServicioLocalStorage) { }

  ngOnInit(): void {
    this.ObtenerCuentasUsuarioLogueado();
  }

  ObtenerCuentasUsuarioLogueado() {
    let usuario: UsuariosModel = this.servicioLocalStorage.ObteniendoCredencialesLocalStorage();
   

    //Datos comprador
    this.NombreComprador = usuario.nombre;
    this.ApellidoComprador = usuario.apellido;

    //Obteniendo pedidos de comprador
    this.ServicioCuentas.ObtenerCuentaPorUsuarioID(usuario.usuarioId).subscribe((resp: RetornoServidor<CuentasModel>) => {
      console.log(resp);
      if (resp.operacionExitosa == true && resp.error == null) {
        if (resp.listadoResultados.length > 0) {
          this.Cuentas = resp.listadoResultados;
          console.log(this.Cuentas);
        }
      } else if (resp.operacionExitosa == true && resp.error != null) {
        this.Cuentas = [];
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
