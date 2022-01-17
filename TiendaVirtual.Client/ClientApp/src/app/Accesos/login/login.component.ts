import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxPermissionsService } from 'ngx-permissions';
import { NgxPermission } from 'ngx-permissions/lib/model/permission.model';
import Swal from 'sweetalert2';
import { RetornoServidor } from '../../Interfaces/RespuestaGenericasServidorInterface/RetornoServidor.Interface';
import { LoginModel } from '../../Modelos/LoginModel/Login.Model';
import { UsuariosModel } from '../../Modelos/UsuarioModel/UsuarioModel';
import { CargarPermisosService } from '../../Servicios/cargar-permisos.service';
import { ServicioAutenticacion } from '../../Servicios/servicio-autenticacion.service';
import { ServicioLocalStorage } from '../../Servicios/servicio-local-storage.service';
import { ServicioMensajeria } from '../../Servicios/servicio-mensajeria.service';
import 'animate.css';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formularioEnviado: boolean = false;
  mostrarLoading: boolean = false;
  credencialesIncorrectas: boolean = false;
  //Usuario: Usuarios[] = [];
  cargandoIngresando: boolean = false;
  anno = new Date().getFullYear();
  mensajeDeError: string = "";
  baseUrl: string = "";


  formulario: FormGroup;
  constructor(private AutenticacionServicio: ServicioAutenticacion, private servicioLocalStorage: ServicioLocalStorage, private route: Router, private formService: FormBuilder, private ServicioCargarPermisosUsuario: CargarPermisosService, private ServicioPermissions: NgxPermissionsService, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.formulario = this.formService.group({
      usuario: ['', [Validators.required, Validators.minLength(1)]],
      contrasena: ['', [Validators.required, Validators.minLength(1)]]
    })
  }

  ngOnInit(): void {
    
  }

  onKeypressEvent(keyevent: any) {
    console.log(this.formulario);
  }


  Login() {
    this.formularioEnviado = true;
    this.credencialesIncorrectas = false;

    if (this.formulario.invalid == false) {
      this.formularioEnviado = false;
      this.cargandoIngresando = true;
      let Usuario: LoginModel = this.formulario.value;
      this.AutenticacionServicio.Login(Usuario).subscribe((resp: RetornoServidor<UsuariosModel>) => {

        if (resp.operacionExitosa == true && resp.error == null) {
          this.servicioLocalStorage.GuardarCredencialesLocalStorage(resp.resultadoEspecifico);
          this.AgregarPermisosUsuarios();
          setTimeout(() => {
            this.cargandoIngresando = false;
            this.mostrarLoading = true;
            setTimeout(() => {
              this.mostrarLoading = false;
              this.route.navigate(['Principal']);
            }, 1500);
          }, 2000);

        } else if (resp.operacionExitosa == true && resp.error != null) {
          this.credencialesIncorrectas = true;
          this.cargandoIngresando = false;
          this.mostrarLoading = false;
          this.mensajeDeError = resp.error;
        } else if (resp.operacionExitosa == false && resp.error != null) {
          this.cargandoIngresando = false;
          Swal.fire({
            icon: 'error',
            title: 'Ha ocurrido un error',
            text: resp.error
          })
        }
      },
        (error: any) => {
          Swal.fire({
            icon: 'error',
            title: 'Ha ocurrido un error',
            text: error.status == 404 ? 'No se encontro el servidor' : error.error
          })
        }
      )
    }
  }

  AgregarPermisosUsuarios() {
    let usuarioRol = this.servicioLocalStorage.ObteniendoCredencialesLocalStorage();
    this.http.get(this.baseUrl + `api/Permisos/${usuarioRol.rolId}`).subscribe((permissions: any) => {
      this.ServicioPermissions.loadPermissions(permissions);
    });
  }

}
