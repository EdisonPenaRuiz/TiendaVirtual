import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'card-cuentas-usuarios',
  templateUrl: './card-cuentas-usuarios.component.html',
  styleUrls: ['./card-cuentas-usuarios.component.css']
})
export class CardCuentasUsuariosComponent {

  @Input() NumeroTarjeta:string="";
  @Input() CuentaID:number=0;
  @Input() Balance:number=0;

  constructor() { }

  ngOnInit(): void {
  }

}
