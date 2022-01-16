import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicioLocalStorage } from '../Servicios/servicio-local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class ProteccionRutaAutenticacionGuard implements CanActivate {

  constructor(private ServiciolocalStorage: ServicioLocalStorage, private router: Router) { }

  ComprobandoAutenticacion(): boolean {
    let usuario = this.ServiciolocalStorage.ObteniendoCredencialesLocalStorage();
    let Autenticado: boolean = false;
    Autenticado = usuario.rolId != undefined ? true : false;
    if (Autenticado == false) { this.router.navigate(['login']) }
    return Autenticado;
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.ComprobandoAutenticacion();
  }
  
}
