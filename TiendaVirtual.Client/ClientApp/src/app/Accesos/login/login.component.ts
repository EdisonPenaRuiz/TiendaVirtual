import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../../Models/Login.Model';
import { Respuesta, RetornoServidor } from '../../Models/RetornoServidor.Model';
import { ServicioAutenticacion } from '../../Servicios/servicio-autenticacion.service';

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
  constructor(private AutenticacionServicio: ServicioAutenticacion, private route: Router, private formService: FormBuilder) {
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
      this.AutenticacionServicio.Login(Usuario).subscribe((data: any) => {
        if (data['operacionExitosa'] == true && data['error'] == null) {
          
            setTimeout(() => {
              this.cargandoIngresando = false;
              this.mostrarLoading = true;
              setTimeout(() => {
                this.mostrarLoading = false;
                //this.route.navigateByUrl('/principal');
              }, 1500);
            }, 2000);
        } else if (data['operacionExitosa'] == true && data['error'] != null) {
          this.credencialesIncorrectas = true;
          this.cargandoIngresando = false;
          this.mostrarLoading = false;
          this.mensajeDeError = data['error'];
        }
      })
    }
  }

}
