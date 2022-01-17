import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { RetornoServidor } from '../../Interfaces/RespuestaGenericasServidorInterface/RetornoServidor.Interface';
import { DiccionarioGenericoModel } from '../../Modelos/DiccionarioGenericoModel/DiccionarioGenericoModel';
import { UsuariosModel } from '../../Modelos/UsuarioModel/UsuarioModel';
import { ServicioAutenticacion } from '../../Servicios/servicio-autenticacion.service';
import { ServicioUsuarios } from '../../Servicios/servicio-usuarios.service';

@Component({
  selector: 'app-registro-usuario',
  templateUrl: './registro-usuario.component.html',
  styleUrls: ['./registro-usuario.component.css']
})
export class RegistroUsuarioComponent implements OnInit {
  formulario: FormGroup;
  RolesUsuarios: DiccionarioGenericoModel[] = [];
  anno = new Date().getFullYear();
  mensajeError = "";
  cargando: boolean = false;

  constructor(private UsuariosServicio: ServicioUsuarios, private route: Router, private formService: FormBuilder) {
    this.formulario = this.formService.group({
      nombre: ['', [Validators.required, Validators.minLength(1)]],
      apellido: ['', [Validators.required, Validators.minLength(1)]],
      usuario: ['', [Validators.required, Validators.minLength(1)]],
      contrasena: ['', [Validators.required, Validators.minLength(1)]],
      rol: [1, [Validators.required, Validators.minLength(1), Validators.min(1), Validators.max(2)]],
      usuarioId:[0]
    })
  }

  ngOnInit(): void {
    //ESTO SE LLENARA DESDE LA BASE DE DATOS
    this.RolesUsuarios.push(new DiccionarioGenericoModel(1, 'Comprador'));
    this.RolesUsuarios.push(new DiccionarioGenericoModel(2, 'Vendedor'));
  }

  Registrar() {
    this.mensajeError = "";
    this.cargando = true;
    //Creando un usuario a partil del formulario
    let usuarioEnviar = new UsuariosModel(
      this.formulario.controls['nombre'].value,
      this.formulario.controls['apellido'].value,
      this.formulario.controls['usuario'].value,
      this.formulario.controls['contrasena'].value,
      this.formulario.controls['rol'].value,
      this.formulario.controls['usuarioId'].value
    );
    this.UsuariosServicio.AgregarUsuario(usuarioEnviar).subscribe((resp: RetornoServidor<UsuariosModel>) => {
      if (resp.operacionExitosa == true && resp.error == null) {
        this.cargando = false;
        Swal.fire({
          icon: 'success',
          title: 'Operacion Realizada!',
          text: `Se ha registrado correctamente el usuario ${resp.resultadoEspecifico.nombre} ${resp.resultadoEspecifico.apellido}`
        })
        this.route.navigate(['/Acceso/login']);
      } else if (resp.operacionExitosa == true && resp.error != null) {
        this.cargando = false;
        this.mensajeError = resp.error
      }
    }, error => {
      this.cargando = false;
      Swal.fire({
        icon: 'error',
        title: 'Ha ocurrido un error',
        text: error.status == 404 ? 'No se encontro el servidor' : error.error
      })
    });

  }
  

}
