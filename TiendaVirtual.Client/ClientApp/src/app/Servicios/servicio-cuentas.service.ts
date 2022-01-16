import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicioCuentas {

  BaseUrl: string = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseUrl = baseUrl;
  }

  ObtenerCuentaPorUsuarioID(UsuarioID: number): Observable<any> {
    return this.http.get(this.BaseUrl + `api/Cuentas/${UsuarioID}`);
  }
}
