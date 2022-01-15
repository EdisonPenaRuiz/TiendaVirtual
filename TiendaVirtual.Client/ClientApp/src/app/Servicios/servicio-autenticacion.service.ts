import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { LoginModel } from '../Models/Login.Model';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ServicioAutenticacionService {

  UrlBase: string = "";
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.UrlBase = baseUrl;
  }

  Login(Usuario: LoginModel) {
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
