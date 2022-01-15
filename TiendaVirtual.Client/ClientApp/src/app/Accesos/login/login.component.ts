import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { LoginModel } from '../../Models/Login.Model';
import { RetornoServidor } from '../../Models/RetornoServidor.Model';
import { UsuariosModel } from '../../Models/UsuarioModel';
import { ServicioAutenticacion } from '../../Servicios/servicio-autenticacion.service';
import { ServicioLocalStorage } from '../../Servicios/servicio-local-storage.service';

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
  mensajeDeError: string="";


  formulario: FormGroup;
  constructor(private AutenticacionServicio: ServicioAutenticacion, private LocalStorageServicio:ServicioLocalStorage, private route: Router, private formService: FormBuilder) {
    this.formulario = this.formService.group({
      usuario: ['', [Validators.required, Validators.minLength(1)]],
      contrasena: ['', [Validators.required, Validators.minLength(1)]]
    })
  }

  ngOnInit(): void {
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
          this.LocalStorageServicio.GuardarCredencialesLocalStorage(resp.resultadoEspecifico)
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

}
