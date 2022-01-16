import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getBaseUrl } from '../../main';
import { ServicioLocalStorage } from './servicio-local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class CargarPermisosService {

  baseUrls: string="";
  constructor(private servicioLocalStorage: ServicioLocalStorage, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrls = baseUrl;
  }

  public Delay() {
    return new Promise(resolve => setTimeout(() => resolve, 3000));
  }

  public loadPermisos() {
    return this.http.get(this.baseUrls + "api/Permisos/0").toPromise().then(() => {
      let permisos: string[] = [];
       
          var usuario = this.servicioLocalStorage.ObteniendoCredencialesLocalStorage();
          if (usuario.rolId == 1) {
          permisos = ['Pedidos-Comprador', 'FormasPagos-Comprador', 'Cuentas-Comprador', 'Mensajes-Comprador']
          } else if (usuario.rolId == 2) {
          permisos = ['Articulo-Vendedor', 'Mensajes-Vendedor']
         };

      return permisos;

    });
  }
}
