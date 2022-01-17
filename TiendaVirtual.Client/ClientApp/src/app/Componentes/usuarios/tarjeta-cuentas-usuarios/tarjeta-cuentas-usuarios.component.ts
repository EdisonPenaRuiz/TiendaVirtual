import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'tarjeta-cuentas-usuarios',
  templateUrl: './tarjeta-cuentas-usuarios.component.html',
  styleUrls: ['./tarjeta-cuentas-usuarios.component.css']
})
export class TarjetaCuentasUsuariosComponent {

  @Input() NumeroTarjeta:string="";
  @Input() CuentaID:number=0;
  @Input() Balance:number=0;

  constructor() { }

  ngOnInit(): void {
  }

}
