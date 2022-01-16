import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicioLocalStorage } from '../Servicios/servicio-local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class ProteccionRutaPorRolesGuard implements CanActivate {

  constructor(private ServiciolocalStorage: ServicioLocalStorage, private router: Router) {

  }

  ComprobandoRole(rol: number, redirect: string) {
    let validado: boolean = false;
    let data = this.ServiciolocalStorage.ObteniendoCredencialesLocalStorage();
    if (data.rolId != undefined) {
      validado = data['rolId'] == rol ? true : false;
      if (validado == false) {
        this.router.navigate([redirect.toString()]);
      }
    } else {
      validado = false;
      this.router.navigate(['login']);
    }
    return validado;
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.ComprobandoRole(route.data.rol,route.data.redirecTo);
  }
  
}
