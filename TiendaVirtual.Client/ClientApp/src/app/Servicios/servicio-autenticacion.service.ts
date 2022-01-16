import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { LoginModel } from '../Models/LoginModel/Login.Model';


@Injectable({
  providedIn: 'root'
})
export class ServicioAutenticacion {

  UrlBase: string = "";
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.UrlBase = baseUrl;
  }

  Login(Usuario: LoginModel): Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.httpClient.post(this.UrlBase + 'api/Login', Usuario, { headers: headers });
  }

  /*
  VerificaToken(token: Token) {
    return this.httpClient.post(this.UrlsService.UrlRaizDB() + '/login/VerificaToken', token);
  }
  */
}
