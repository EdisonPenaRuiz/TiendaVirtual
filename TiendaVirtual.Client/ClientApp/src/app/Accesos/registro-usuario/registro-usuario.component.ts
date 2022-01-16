import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DiccionarioGenericoModel } from '../../Models/DiccionarioGenericoModel/DiccionarioGenericoModel';
import { UsuariosModel } from '../../Models/UsuarioModel/UsuarioModel';
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

  constructor(private UsuariosServicio: ServicioUsuarios, private route: Router, private formService: FormBuilder) {
    this.formulario = this.formService.group({
      nombre: ['', [Validators.required, Validators.minLength(1)]],
      apellido: ['', [Validators.required, Validators.minLength(1)]],
      usuario: ['', [Validators.required, Validators.minLength(1)]],
      contrasena: ['', [Validators.required, Validators.minLength(1)]],
      rol: [1, [Validators.required, Validators.minLength(1), Validators.min(1), Validators.max(2)]]
    })
  }

  ngOnInit(): void {
    //ESTO SE LLENARA DESDE LA BASE DE DATOS
    this.RolesUsuarios.push(new DiccionarioGenericoModel(1, 'Comprador'));
    this.RolesUsuarios.push(new DiccionarioGenericoModel(2, 'Vendedor'));
  }

  Registrar() {
    this.mensajeError = "";

    //Creando un usuario a partil del formulario
    let usuarioEnviar = new UsuariosModel(
      this.formulario.controls['nombre'].value,
      this.formulario.controls['apellido'].value,
      this.formulario.controls['usuario'].value,
      this.formulario.controls['contrasena'].value,
      this.formulario.controls['rol'].value
    );
    this.UsuariosServicio.AgregarUsuario(usuarioEnviar).subscribe((resp: any) => {
      console.log(resp);
      if (resp['operacionExitosa'] == true && resp['error'] == null) {
        this.route.navigate(['/Acceso/login']);
      } else {
        this.mensajeError = resp['error'];
      }
    }, error => {
      console.log(error);
    });

  }
  

}
