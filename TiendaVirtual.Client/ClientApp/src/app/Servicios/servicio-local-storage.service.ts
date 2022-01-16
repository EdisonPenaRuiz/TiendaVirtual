import { Injectable } from '@angular/core';
import { UsuariosModel } from '../Models/UsuarioModel/UsuarioModel';

@Injectable({
  providedIn: 'root'
})
export class ServicioLocalStorage {

  constructor() { }

  GuardarCredencialesLocalStorage(usuario: UsuariosModel) {
    localStorage.setItem('credenciales-usuario', JSON.stringify(usuario));
  }

  ObteniendoCredencialesLocalStorage() {
    return JSON.parse(localStorage.getItem('credenciales-usuario') || '{}');
  }

  RemoviendoCredencialesLocalStorage() {
    localStorage.removeItem('credenciales-usuario')
  }
}
