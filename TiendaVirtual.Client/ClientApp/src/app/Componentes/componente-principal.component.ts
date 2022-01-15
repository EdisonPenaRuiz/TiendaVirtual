import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-componente-principal',
  templateUrl: './componente-principal.component.html',
  styleUrls: ['./componente-principal.component.css']
})
export class ComponentePrincipalComponent implements OnInit {

  constructor() { }
  mostrarMenu: boolean = true;

  ngOnInit(): void {
  }

  ExpandirExtraerMenu(mostrar: any) {
    this.mostrarMenu = !this.mostrarMenu;
  }

}
