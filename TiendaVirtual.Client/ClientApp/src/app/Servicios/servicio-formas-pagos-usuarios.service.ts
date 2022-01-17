import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FormasPagosUsuariosModel } from '../Modelos/FormasPagosModel/FormasPagosUsuarios.Model';

@Injectable({
  providedIn: 'root'
})
export class ServicioFormasPagosUsuarios {

  BaseUrl: string = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseUrl = baseUrl;
  }

  ObtenerFormasPagosPorUsuarioID(usuarioID: number): Observable<any> {
    return this.http.get(this.BaseUrl + `api/FormaPagos/${usuarioID}`);
  }

  ActualizarFormasPagos(formaPago: FormasPagosUsuariosModel): Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.http.put(this.BaseUrl + `api/FormaPagos/`, formaPago, { headers: headers });
  }

  AgregarFormasPagos(formaPago: FormasPagosUsuariosModel): Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.http.post(this.BaseUrl + `api/FormaPagos/`, formaPago, { headers: headers });
  }

  EliminarFormasPagos(formaPagoID: number): Observable<any> {
    return this.http.delete(this.BaseUrl + `api/FormaPagos/${formaPagoID}`);
  }


}
