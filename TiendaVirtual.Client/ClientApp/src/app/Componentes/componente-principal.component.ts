import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgxPermissionsService } from 'ngx-permissions';

@Component({
  selector: 'app-componente-principal',
  templateUrl: './componente-principal.component.html',
  styleUrls: ['./componente-principal.component.css']
})
export class ComponentePrincipal implements OnInit {

  constructor(private permissionsService: NgxPermissionsService, private http: HttpClient) { }
  mostrarMenu: boolean = true;

  ngOnInit(): void {
    
  }

  ExpandirExtraerMenu(mostrar: any) {
    this.mostrarMenu = !this.mostrarMenu;
  }

}
